namespace StoreDAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The named product within a category (e.g. "iPhone 15"), which one or more <see cref="Product"/>
/// rows (by manufacturer) can reference.
/// </summary>
[Table("product_titles")]
public class ProductTitle : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTitle"/> class.
    /// </summary>
    public ProductTitle()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTitle"/> class.
    /// </summary>
    /// <param name="id">The product title identifier.</param>
    /// <param name="title">The title text.</param>
    /// <param name="categoryId">The identifier of the owning category.</param>
    public ProductTitle(int id, string title, int categoryId)
        : base(id)
    {
        this.Title = title;
        this.CategoryId = categoryId;
    }

    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    [Column("product_title")]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the owning category.
    /// </summary>
    [Column("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the owning category.
    /// </summary>
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets the products that use this title.
    /// </summary>
    public virtual IList<Product> Products { get; set; }
}
