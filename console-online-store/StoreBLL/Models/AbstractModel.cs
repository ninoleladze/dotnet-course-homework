namespace StoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Base class for every BLL-facing model, providing the shared identifier.
/// </summary>
public abstract class AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractModel"/> class.
    /// </summary>
    /// <param name="id">The record's identifier.</param>
    protected AbstractModel(int id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets or sets the record's identifier.
    /// </summary>
    public int Id { get; set; }
}
