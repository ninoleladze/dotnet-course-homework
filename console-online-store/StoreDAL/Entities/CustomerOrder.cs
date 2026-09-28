namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// An order placed by a customer, made up of one or more <see cref="OrderDetail"/> line items.
/// </summary>
[Table("customer_orders")]
public class CustomerOrder : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrder"/> class.
    /// </summary>
    public CustomerOrder()
     : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrder"/> class.
    /// </summary>
    /// <param name="id">The order identifier.</param>
    /// <param name="operationTime">The timestamp the order was placed or last changed.</param>
    /// <param name="userId">The identifier of the customer who placed the order.</param>
    /// <param name="orderStateId">The identifier of the order's current state.</param>
    public CustomerOrder(int id, string operationTime, int userId, int orderStateId)
        : base(id)
    {
        this.OperationTime = operationTime;
        this.UserId = userId;
        this.OrderStateId = orderStateId;
    }

    /// <summary>
    /// Gets or sets the identifier of the customer who placed the order.
    /// </summary>
    [Column("customer_id")]
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp the order was placed or last changed.
    /// </summary>
    [Column("operation_time")]
    public string OperationTime { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the order's current state.
    /// </summary>
    [Column("order_state_id")]
    public int OrderStateId { get; set; }

    /// <summary>
    /// Gets or sets the customer who placed the order.
    /// </summary>
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the order's current state.
    /// </summary>
    [ForeignKey(nameof(OrderStateId))]
    public OrderState State { get; set; }

    /// <summary>
    /// Gets or sets the line items that make up this order.
    /// </summary>
    public virtual IList<OrderDetail> Details { get; set; }
}