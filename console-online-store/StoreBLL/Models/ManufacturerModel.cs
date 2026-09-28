namespace StoreBLL.Models;

/// <summary>
/// BLL-facing representation of a product manufacturer.
/// </summary>
public class ManufacturerModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ManufacturerModel"/> class.
    /// </summary>
    /// <param name="id">The manufacturer identifier.</param>
    /// <param name="name">The manufacturer name.</param>
    public ManufacturerModel(int id, string name)
        : base(id)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the manufacturer name.
    /// </summary>
    public string Name { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.Name}";
    }
}
