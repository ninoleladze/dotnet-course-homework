namespace StoreBLL.Models;

/// <summary>
/// BLL-facing representation of a product category.
/// </summary>
public class CategoryModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryModel"/> class.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="name">The category name.</param>
    public CategoryModel(int id, string name)
        : base(id)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the category name.
    /// </summary>
    public string Name { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.Name}";
    }
}
