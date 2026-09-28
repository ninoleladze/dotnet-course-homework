namespace StoreBLL.Models;
using System.Globalization;

/// <summary>
/// BLL-facing representation of a customer order.
/// </summary>
public class CustomerOrderModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerOrderModel"/> class.
    /// </summary>
    /// <param name="id">The order identifier.</param>
    /// <param name="operationTime">The timestamp the order was placed or last changed.</param>
    /// <param name="userId">The identifier of the customer who placed the order.</param>
    /// <param name="orderStateId">The identifier of the order's current state.</param>
    public CustomerOrderModel(int id, string operationTime, int userId, int orderStateId)
        : base(id)
    {
        this.OperationTime = operationTime;
        this.UserId = userId;
        this.OrderStateId = orderStateId;
    }

    /// <summary>
    /// Gets or sets the timestamp the order was placed or last changed.
    /// </summary>
    public string OperationTime { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the customer who placed the order.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the order's current state.
    /// </summary>
    public int OrderStateId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the order's current state, when known.
    /// </summary>
    public string? OrderStateName { get; set; }

    /// <summary>
    /// Gets or sets the total price of the order, when known.
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var state = this.OrderStateName ?? this.OrderStateId.ToString(CultureInfo.InvariantCulture);
        return $"Id:{this.Id} time:{this.OperationTime} customerId:{this.UserId} state:{state} total:{this.TotalPrice.ToString("C", CultureInfo.InvariantCulture)}";
    }
}
