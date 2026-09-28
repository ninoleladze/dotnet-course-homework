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
/// Base class for the hotkey actions shown inside a <see cref="ConsoleMenu.ContextMenu"/>, backed by
/// a single <see cref="ICrud"/> service.
/// </summary>
public abstract class ContextMenuHandler
{
    /// <summary>
    /// The service backing this handler's actions.
    /// </summary>
    protected readonly ICrud service;

    /// <summary>
    /// Reads a model from the console, used by actions that create or edit a record.
    /// </summary>
    protected readonly Func<AbstractModel> readModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenuHandler"/> class.
    /// </summary>
    /// <param name="service">The service backing this handler's actions.</param>
    /// <param name="readModel">Reads a model from the console for create/edit actions.</param>
    protected ContextMenuHandler(ICrud service, Func<AbstractModel> readModel)
    {
        this.service = service;
        this.readModel = readModel;
    }

    /// <summary>
    /// Prompts for a record id and prints that record's details.
    /// </summary>
    public void GetItemDetails()
    {
        Console.WriteLine("Input record ID for more details");
        int id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine(this.service.GetById(id));
    }

    /// <summary>
    /// Gets the hotkey/caption/action entries this handler contributes to its menu.
    /// </summary>
    /// <returns>The menu entries.</returns>
    public abstract (ConsoleKey id, string caption, Action action)[] GenerateMenuItems();
}
