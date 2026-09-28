namespace StoreBLL.Models;
using System.Globalization;

/// <summary>
/// BLL-facing representation of a product title (the named product within a category, e.g. "iPhone 15").
/// </summary>
public class ProductTitleModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTitleModel"/> class.
    /// </summary>
    /// <param name="id">The product title identifier.</param>
    /// <param name="title">The title text.</param>
    /// <param name="categoryId">The identifier of the owning category.</param>
    public ProductTitleModel(int id, string title, int categoryId)
        : base(id)
    {
        this.Title = title;
        this.CategoryId = categoryId;
    }

    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the owning category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the owning category, when known.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var category = this.CategoryName ?? this.CategoryId.ToString(CultureInfo.InvariantCulture);
        return $"Id:{this.Id} {this.Title} (category: {category})";
    }
}
