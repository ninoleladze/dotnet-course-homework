using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenuHandlers;
using ConsoleApp1;
using StoreBLL.Interfaces;
using StoreBLL.Models;

namespace ConsoleMenu
{
    /// <summary>
    /// A <see cref="Menu"/> that, before every redraw, lists the current records from a data source
    /// (e.g. "Current DataSet") above the hotkey list built from a <see cref="ContextMenuHandler"/>.
    /// </summary>
    public class ContextMenu : Menu
    {
        private readonly Func<IEnumerable<AbstractModel>> getAll;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenu"/> class driven by an
        /// administrator add/remove/edit/view handler.
        /// </summary>
        /// <param name="controller">The handler providing the menu entries.</param>
        /// <param name="getAll">Lists the records to display above the menu.</param>
        public ContextMenu(AdminContextMenuHandler controller, Func<IEnumerable<AbstractModel>> getAll)
            : base(controller?.GenerateMenuItems() !)
        {
            ArgumentNullException.ThrowIfNull(controller);
            this.getAll = getAll;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenu"/> class driven by any menu-item
        /// generator (e.g. a read-only <c>GuestContextMenuHandler</c> or the shopping handler).
        /// </summary>
        /// <param name="generateMenuItems">Produces the hotkey/caption/action entries to show.</param>
        /// <param name="getAll">Lists the records to display above the menu.</param>
        public ContextMenu(Func<(ConsoleKey id, string caption, Action action)[]> generateMenuItems, Func<IEnumerable<AbstractModel>> getAll)
            : base(generateMenuItems())
        {
            this.getAll = getAll;
        }

        /// <inheritdoc/>
        public override void Run()
        {
            ConsoleKey resKey;
            bool updateItems = true;
            do
            {
                if (updateItems)
                {
                    Console.WriteLine("======= Current DataSet ==========");
                    foreach (var record in this.getAll())
                    {
                        Console.WriteLine(record);
                    }

                    Console.WriteLine("===================================");
                }

                resKey = this.RunOnce(ref updateItems);
            }
            while (resKey != ConsoleKey.Escape);
        }
    }
}
