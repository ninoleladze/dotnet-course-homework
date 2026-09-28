namespace StoreDAL.Entities;
using StoreDAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// A top-level product grouping (e.g. "fruits", "smartphones") that product titles belong to.
/// </summary>
[Table("categories")]
public class Category : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    public Category()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="name">The category name.</param>
    public Category(int id, string name)
        : base(id)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the category name.
    /// </summary>
    [Column("category_name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the product titles that belong to this category.
    /// </summary>
    public virtual IList<ProductTitle> Titles { get; set; }
}
