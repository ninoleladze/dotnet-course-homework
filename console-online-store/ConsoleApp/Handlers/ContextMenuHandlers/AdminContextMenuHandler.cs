namespace ConsoleApp.Handlers.ContextMenuHandlers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Interfaces;
using StoreBLL.Models;

/// <summary>
/// Full add/remove/edit/view menu for a record type, backed by an <see cref="ICrud"/> service.
/// Administrator-only.
/// </summary>
public class AdminContextMenuHandler : ContextMenuHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdminContextMenuHandler"/> class.
    /// </summary>
    /// <param name="service">The service backing add/remove/edit/view.</param>
    /// <param name="readModel">Reads a model from the console for add/edit.</param>
    public AdminContextMenuHandler(ICrud service, Func<AbstractModel> readModel)
        : base(service, readModel)
    {
    }

    /// <summary>
    /// Reads a new record from the console and adds it.
    /// </summary>
    public void AddItem()
    {
        this.service.Add(this.readModel());
    }

    /// <summary>
    /// Prompts for a record id and removes it.
    /// </summary>
    public void RemoveItem()
    {
        Console.WriteLine("Input record ID that will be removed");
        int id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        this.service.Delete(id);
    }

    /// <summary>
    /// Prompts for a record id, reads the new values from the console, and persists them.
    /// </summary>
    public void EditItem()
    {
        Console.WriteLine("Input record ID that will be edited");
        int id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        var record = this.readModel();

        // TODO
        this.service.Update(record);
    }

    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GenerateMenuItems()
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.A, "Add Item", this.AddItem),
                (ConsoleKey.R, "Remove Item", this.RemoveItem),
                (ConsoleKey.E, "Edit Item", this.EditItem),
                (ConsoleKey.V, "View Details", this.GetItemDetails),
            };
        return array;
    }
}
