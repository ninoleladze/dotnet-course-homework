namespace StoreBLL.Models;
using System.Globalization;

/// <summary>
/// BLL-facing representation of a single line item within a customer order.
/// </summary>
public class OrderDetailModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetailModel"/> class.
    /// </summary>
    /// <param name="id">The order detail identifier.</param>
    /// <param name="orderId">The identifier of the owning order.</param>
    /// <param name="productId">The identifier of the ordered product.</param>
    /// <param name="price">The unit price at the time the order was placed.</param>
    /// <param name="productAmount">The quantity ordered.</param>
    public OrderDetailModel(int id, int orderId, int productId, decimal price, int productAmount)
        : base(id)
    {
        this.OrderId = orderId;
        this.ProductId = productId;
        this.Price = price;
        this.ProductAmount = productAmount;
    }

    /// <summary>
    /// Gets or sets the identifier of the owning order.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the ordered product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the unit price at the time the order was placed.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the quantity ordered.
    /// </summary>
    public int ProductAmount { get; set; }

    /// <summary>
    /// Gets or sets the display name of the ordered product, when known.
    /// </summary>
    public string? ProductName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var product = this.ProductName ?? "ProductId:" + this.ProductId.ToString(CultureInfo.InvariantCulture);
        var subtotal = (this.Price * this.ProductAmount).ToString("C", CultureInfo.InvariantCulture);
        return $"Id:{this.Id} order:{this.OrderId} {product} x{this.ProductAmount} @ {this.Price.ToString("C", CultureInfo.InvariantCulture)} = {subtotal}";
    }
}
