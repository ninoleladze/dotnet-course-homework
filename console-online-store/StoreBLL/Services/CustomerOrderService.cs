namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

/// <summary>
/// Business logic for placing, browsing and changing the status of customer orders.
/// </summary>
public class CustomerOrderService : ICrud
{
    private readonly ICustomerOrderRepository orderRepository;
    private readonly IOrderDetailRepository detailRepository;
    private readonly IProductRepository productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrderService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public CustomerOrderService(StoreDbContext context)
    {
        this.orderRepository = new CustomerOrderRepository(context);
        this.detailRepository = new OrderDetailRepository(context);
        this.productRepository = new ProductRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        this.orderRepository.Add(new CustomerOrder(x.Id, x.OperationTime, x.UserId, x.OrderStateId));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.orderRepository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.orderRepository.GetAll().Select(ToModel);
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.orderRepository.GetById(id);
        return ToModel(res);
    }

    /// <summary>
    /// Changes an order's status, silently keeping the current status if the transition is not
    /// allowed by the order state machine. Use <see cref="ChangeStatus(int, int)"/> instead when
    /// the caller needs to know whether the change succeeded.
    /// </summary>
    /// <param name="model">The model carrying the order id and the requested new status.</param>
    public void Update(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        this.TryChangeState(x.Id, x.OrderStateId);
    }

    /// <summary>
    /// Places a new order for a customer with status "New Order", capturing each product's current
    /// unit price as the order-line price.
    /// </summary>
    /// <param name="userId">The identifier of the customer placing the order.</param>
    /// <param name="items">The products and quantities to order.</param>
    /// <returns>The newly created order.</returns>
    /// <exception cref="InvalidOperationException">Thrown when <paramref name="items"/> is empty or references an unknown product.</exception>
    public CustomerOrderModel CreateOrder(int userId, IReadOnlyList<(int ProductId, int Amount)> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        if (items.Count == 0)
        {
            throw new InvalidOperationException("An order must contain at least one item.");
        }

        var order = new CustomerOrder(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), userId, OrderStateIds.NewOrder);
        this.orderRepository.Add(order);

        foreach (var item in items)
        {
            var product = this.productRepository.GetById(item.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with id {item.ProductId} was not found.");
            }

            this.detailRepository.Add(new OrderDetail(0, order.Id, product.Id, product.UnitPrice, item.Amount));
        }

        return ToModel(this.orderRepository.GetById(order.Id));
    }

    /// <summary>
    /// Gets the order history for a customer, most recent first.
    /// </summary>
    /// <param name="userId">The identifier of the customer.</param>
    /// <returns>The customer's orders.</returns>
    public IEnumerable<CustomerOrderModel> GetOrderHistory(int userId)
    {
        return this.orderRepository.GetByUserId(userId).Select(ToModel);
    }

    /// <summary>
    /// Cancels an order on behalf of its owner. Only orders in "New Order" or "Confirmed" state can
    /// be cancelled by their owner.
    /// </summary>
    /// <param name="orderId">The identifier of the order to cancel.</param>
    /// <param name="userId">The identifier of the customer requesting the cancellation.</param>
    /// <returns><see langword="true"/> if the order was cancelled; otherwise <see langword="false"/>.</returns>
    public bool CancelByUser(int orderId, int userId)
    {
        var order = this.orderRepository.GetById(orderId);
        if (order == null || order.UserId != userId)
        {
            return false;
        }

        return this.TryChangeState(orderId, OrderStateIds.CanceledByUser);
    }

    /// <summary>
    /// Lets the owning customer confirm they received a delivered order.
    /// </summary>
    /// <param name="orderId">The identifier of the order to confirm.</param>
    /// <param name="userId">The identifier of the customer confirming receipt.</param>
    /// <returns><see langword="true"/> if the order was marked received; otherwise <see langword="false"/>.</returns>
    public bool ConfirmDeliveryReceived(int orderId, int userId)
    {
        var order = this.orderRepository.GetById(orderId);
        if (order == null || order.UserId != userId)
        {
            return false;
        }

        return this.TryChangeState(orderId, OrderStateIds.DeliveryConfirmedByClient);
    }

    /// <summary>
    /// Changes an order's status. Administrator-only: unlike <see cref="CancelByUser(int, int)"/> and
    /// <see cref="ConfirmDeliveryReceived(int, int)"/>, this does not check order ownership.
    /// </summary>
    /// <param name="orderId">The identifier of the order to update.</param>
    /// <param name="newStateId">The requested new order state identifier.</param>
    /// <returns><see langword="true"/> if the transition was allowed and applied; otherwise <see langword="false"/>.</returns>
    public bool ChangeStatus(int orderId, int newStateId)
    {
        return this.TryChangeState(orderId, newStateId);
    }

    private static CustomerOrderModel ToModel(CustomerOrder entity)
    {
        var total = entity.Details?.Sum(d => d.Price * d.ProductAmount) ?? 0m;
        return new CustomerOrderModel(entity.Id, entity.OperationTime, entity.UserId, entity.OrderStateId)
        {
            OrderStateName = entity.State?.StateName,
            TotalPrice = total,
        };
    }

    private bool TryChangeState(int orderId, int newStateId)
    {
        var order = this.orderRepository.GetById(orderId);
        if (order == null)
        {
            return false;
        }

        if (!OrderStateTransitionValidator.IsTransitionAllowed(order.OrderStateId, newStateId))
        {
            return false;
        }

        order.OrderStateId = newStateId;
        this.orderRepository.Update(order);
        return true;
    }
}
