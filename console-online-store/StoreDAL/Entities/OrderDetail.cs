namespace StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// A single line item within a <see cref="CustomerOrder"/>: a product, quantity, and the unit
/// price captured at the time the order was placed.
/// </summary>
[Table("customer_order_details")]
public class OrderDetail : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetail"/> class.
    /// </summary>
    public OrderDetail()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetail"/> class.
    /// </summary>
    /// <param name="id">The order detail identifier.</param>
    /// <param name="orderId">The identifier of the owning order.</param>
    /// <param name="productId">The identifier of the ordered product.</param>
    /// <param name="price">The unit price at the time the order was placed.</param>
    /// <param name="amount">The quantity ordered.</param>
    public OrderDetail(int id, int orderId, int productId, decimal price, int amount)
        : base(id)
    {
        this.OrderId = orderId;
        this.ProductId = productId;
        this.Price = price;
        this.ProductAmount = amount;
    }

    /// <summary>
    /// Gets or sets the identifier of the owning order.
    /// </summary>
    [Column("customer_order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the ordered product.
    /// </summary>
    [Column("product_id")]
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the unit price at the time the order was placed.
    /// </summary>
    [Column("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the quantity ordered.
    /// </summary>
    [Column("product_amount")]
    public int ProductAmount { get; set; }

    /// <summary>
    /// Gets or sets the owning order.
    /// </summary>
    [ForeignKey(nameof(OrderId))]
    public CustomerOrder Order { get; set; }

    /// <summary>
    /// Gets or sets the ordered product.
    /// </summary>
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}
