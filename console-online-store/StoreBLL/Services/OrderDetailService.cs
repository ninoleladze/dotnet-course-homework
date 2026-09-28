namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

/// <summary>
/// Business logic for the individual line items that make up a customer order.
/// </summary>
public class OrderDetailService : ICrud
{
    private readonly IOrderDetailRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetailService"/> class.
    /// </summary>
    /// <param name="context">The database context to operate on.</param>
    public OrderDetailService(StoreDbContext context)
    {
        this.repository = new OrderDetailRepository(context);
    }

    /// <inheritdoc/>
    public void Add(AbstractModel model)
    {
        var x = (OrderDetailModel)model;
        this.repository.Add(new OrderDetail(x.Id, x.OrderId, x.ProductId, x.Price, x.ProductAmount));
    }

    /// <inheritdoc/>
    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    /// <inheritdoc/>
    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(ToModel);
    }

    /// <inheritdoc/>
    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return ToModel(res);
    }

    /// <summary>
    /// Gets every line item belonging to a given order.
    /// </summary>
    /// <param name="orderId">The identifier of the owning order.</param>
    /// <returns>The order's line items.</returns>
    public IEnumerable<OrderDetailModel> GetByOrderId(int orderId)
    {
        return this.repository.GetByOrderId(orderId).Select(ToModel);
    }

    /// <inheritdoc/>
    public void Update(AbstractModel model)
    {
        var x = (OrderDetailModel)model;
        var existing = this.repository.GetById(x.Id);
        if (existing == null)
        {
            throw new InvalidOperationException($"Order detail with id {x.Id} was not found.");
        }

        existing.ProductId = x.ProductId;
        existing.Price = x.Price;
        existing.ProductAmount = x.ProductAmount;
        this.repository.Update(existing);
    }

    private static OrderDetailModel ToModel(OrderDetail entity)
    {
        return new OrderDetailModel(entity.Id, entity.OrderId, entity.ProductId, entity.Price, entity.ProductAmount)
        {
            ProductName = entity.Product?.Title?.Title,
        };
    }
}
