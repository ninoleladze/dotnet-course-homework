namespace ConsoleApp.Handlers.ContextMenuHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Interfaces;
using StoreBLL.Models;

/// <summary>
/// Read-only "View Details" menu for a record type. Used for browsing (e.g. the product catalog)
/// where the current role isn't allowed to add, remove, or edit.
/// </summary>
public class GuestContextMenuHandler : ContextMenuHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GuestContextMenuHandler"/> class.
    /// </summary>
    /// <param name="service">The service backing "View Details".</param>
    /// <param name="readModel">Unused by this handler; kept for compatibility with the base menu framework.</param>
    public GuestContextMenuHandler(ICrud service, Func<AbstractModel> readModel)
        : base(service, readModel)
    {
    }

    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GenerateMenuItems()
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.V, "View Details", this.GetItemDetails),
            };
        return array;
    }
}
