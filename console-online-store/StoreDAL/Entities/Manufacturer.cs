namespace StoreDAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreDAL.Entities;

/// <summary>
/// The company that makes a product.
/// </summary>
[Table("manufacturers")]
public class Manufacturer : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Manufacturer"/> class.
    /// </summary>
    public Manufacturer()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Manufacturer"/> class.
    /// </summary>
    /// <param name="id">The manufacturer identifier.</param>
    /// <param name="name">The manufacturer name.</param>
    public Manufacturer(int id, string name)
        : base(id)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the manufacturer name.
    /// </summary>
    [Column("manufacturer_name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the products made by this manufacturer.
    /// </summary>
    public virtual IList<Product> Products { get; set; }
}
