namespace StoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A status a <see cref="CustomerOrder"/> can be in (e.g. "New Order", "Delivered to client").
/// Which transitions between states are allowed is enforced by
/// <see cref="StoreBLL.Services.OrderStateTransitionValidator"/>, not by this entity.
/// </summary>
[Table("order_states")]
public class OrderState : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderState"/> class.
    /// </summary>
    public OrderState()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderState"/> class.
    /// </summary>
    /// <param name="id">The state identifier.</param>
    /// <param name="stateName">The state's display name.</param>
    public OrderState(int id, string stateName)
        : base(id)
    {
        this.StateName = stateName;
    }

    /// <summary>
    /// Gets or sets the state's display name.
    /// </summary>
    [Column("state_name")]
    public string StateName { get; set; }

    /// <summary>
    /// Gets or sets the orders currently in this state.
    /// </summary>
    public virtual IList<CustomerOrder> Order { get; set; }
}
