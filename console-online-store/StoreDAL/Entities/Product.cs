namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A concrete, purchasable item in the store: a title from a given manufacturer, priced per unit.
/// </summary>
[Table("products")]
public class Product : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    public Product()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="titleId">The identifier of the product's title.</param>
    /// <param name="manufacturerId">The identifier of the product's manufacturer.</param>
    /// <param name="description">A free-text description/comment for the product.</param>
    /// <param name="price">The price for a single unit.</param>
    public Product(int id, int titleId, int manufacturerId, string description, decimal price)
        : base(id)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.Description = description;
        this.UnitPrice = price;
    }

    /// <summary>
    /// Gets or sets the identifier of the product's title.
    /// </summary>
    [Column("product_title_id")]
    public int TitleId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product's manufacturer.
    /// </summary>
    [Column("manufacturer_id")]
    public int ManufacturerId { get; set; }

    /// <summary>
    /// Gets or sets the price for a single unit.
    /// </summary>
    [Column("unit_price")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets a free-text description/comment for the product.
    /// </summary>
    [Column("comment")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the product's title.
    /// </summary>
    [ForeignKey(nameof(TitleId))]
    public ProductTitle Title { get; set; }

    /// <summary>
    /// Gets or sets the product's manufacturer.
    /// </summary>
    [ForeignKey(nameof(ManufacturerId))]
    public Manufacturer Manufacturer { get; set; }

    /// <summary>
    /// Gets or sets the order line items that reference this product.
    /// </summary>
    public virtual IList<OrderDetail> OrderDetails { get; set; }
}