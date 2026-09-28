namespace StoreBLL.Models;
using System.Globalization;

/// <summary>
/// BLL-facing representation of a product offered by the store.
/// </summary>
public class ProductModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductModel"/> class.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="titleId">The identifier of the product's title.</param>
    /// <param name="manufacturerId">The identifier of the product's manufacturer.</param>
    /// <param name="description">A free-text description/comment for the product.</param>
    /// <param name="unitPrice">The price for a single unit.</param>
    public ProductModel(int id, int titleId, int manufacturerId, string description, decimal unitPrice)
        : base(id)
    {
        this.TitleId = titleId;
        this.ManufacturerId = manufacturerId;
        this.Description = description;
        this.UnitPrice = unitPrice;
    }

    /// <summary>
    /// Gets or sets the identifier of the product's title.
    /// </summary>
    public int TitleId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product's manufacturer.
    /// </summary>
    public int ManufacturerId { get; set; }

    /// <summary>
    /// Gets or sets the price for a single unit.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets a free-text description/comment for the product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the display name of the product's title, when known.
    /// </summary>
    public string? TitleName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the product's category, when known.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the product's manufacturer, when known.
    /// </summary>
    public string? ManufacturerName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var title = this.TitleName ?? "TitleId:" + this.TitleId.ToString(CultureInfo.InvariantCulture);
        var manufacturer = this.ManufacturerName ?? "ManufacturerId:" + this.ManufacturerId.ToString(CultureInfo.InvariantCulture);
        var category = this.CategoryName is null ? string.Empty : $" [{this.CategoryName}]";
        return $"Id:{this.Id} {title}{category} by {manufacturer} - {this.UnitPrice.ToString("C", CultureInfo.InvariantCulture)} - {this.Description}";
    }
}
