namespace StoreBLL.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// BLL-facing representation of an order state (e.g. "New Order", "Delivered to client").
/// </summary>
public class OrderStateModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderStateModel"/> class.
    /// </summary>
    /// <param name="id">The state identifier.</param>
    /// <param name="stateName">The state's display name.</param>
    public OrderStateModel(int id, string stateName)
        : base(id)
    {
        this.Id = id;
        this.StateName = stateName;
    }

    /// <summary>
    /// Gets or sets the state's display name.
    /// </summary>
    public string StateName { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.StateName}";
    }
}
