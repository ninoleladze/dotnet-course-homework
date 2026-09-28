/*
Yuriy Antonov copyright 2018-2020
*/

namespace ConsoleMenu
{
    /// <summary>
    /// A hotkey-driven console menu: each entry is bound to a <see cref="ConsoleKey"/> and runs
    /// until the user presses <see cref="ConsoleKey.Escape"/>.
    /// </summary>
    public class Menu
    {
        private readonly Dictionary<ConsoleKey, MenuItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with no entries.
        /// </summary>
        public Menu()
        {
            this.items = new Dictionary<ConsoleKey, MenuItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with a single entry.
        /// </summary>
        /// <param name="id">The hotkey for the entry.</param>
        /// <param name="caption">The text shown to the user.</param>
        /// <param name="action">The action to run when the entry is chosen.</param>
        public Menu(ConsoleKey id, string caption, Action action)
        {
            this.items = new Dictionary<ConsoleKey, MenuItem>();
            this.items.Add(id, new MenuItem(caption, action));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with the given entries.
        /// </summary>
        /// <param name="array">The hotkey/caption/action triples to show as menu entries.</param>
        public Menu((ConsoleKey id, string caption, Action action)[] array)
        {
            ArgumentNullException.ThrowIfNull(array);
            this.items = new Dictionary<ConsoleKey, MenuItem>();
            foreach (var elem in array)
            {
                if (!this.items.ContainsKey(elem.id))
                {
                    this.items.Add(elem.id, new MenuItem(elem.caption, elem.action));
                }
            }
        }

        /// <summary>
        /// Runs the menu loop until the user presses <see cref="ConsoleKey.Escape"/>.
        /// </summary>
        public virtual void Run()
        {
            ConsoleKey resKey;
            bool updateItems = true;
            do
            {
                resKey = this.RunOnce(ref updateItems);
            }
            while (resKey != ConsoleKey.Escape);
        }

        /// <summary>
        /// Redraws the menu (if <paramref name="updateItems"/> is <see langword="true"/>), waits for
        /// one keypress, and runs the matching entry's action if any.
        /// </summary>
        /// <param name="updateItems">
        /// Whether to redraw the menu before waiting for input; set to <see langword="true"/> on
        /// return whenever an action ran, so the next call redraws.
        /// </param>
        /// <returns>The key that was pressed.</returns>
        public /*virtual*/ ConsoleKey RunOnce(ref bool updateItems)
        {
            ConsoleKeyInfo res;
            if (updateItems)
            {
                    foreach (var item in this.items)
                    {
                        Console.WriteLine($"<{item.Key}>:  {item.Value}");
                    }

                    Console.WriteLine("Or press <Esc> to return");
            }

            res = Console.ReadKey(true);
            if (this.items.ContainsKey(res.Key))
            {
                this.items[res.Key].Action();
                updateItems = true;
            }
            else
            {
                updateItems = false;
            }

            return res.Key;
        }

        /// <summary>
        /// Legacy, non-<c>ref</c> equivalent of <see cref="Run"/>. Kept for reference; superseded by
        /// <see cref="Run"/>/<see cref="RunOnce"/>.
        /// </summary>
        public void RunOld()
        {
            ConsoleKeyInfo res;
            bool updateItems = true;
            do
            {
                if (updateItems)
                {
                    foreach (var item in this.items)
                    {
                        Console.WriteLine($"<{item.Key}>:  {item.Value}");
                    }

                    Console.WriteLine("Or press <Esc> to return");
                }

                res = Console.ReadKey(true);
                if (this.items.ContainsKey(res.Key))
                {
                    this.items[res.Key].Action();
                    updateItems = true;
                }
                else
                {
                    updateItems = false;
                }
            }
            while (res.Key != ConsoleKey.Escape);
        }
    }
}
