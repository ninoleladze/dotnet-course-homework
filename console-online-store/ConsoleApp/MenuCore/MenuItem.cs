/*
Yuriy Antonov copyright 2018-2020
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    /// <summary>
    /// A single menu entry: the text shown to the user and the action to run when it is chosen.
    /// </summary>
    public class MenuItem
    {
        private readonly string caption;
        private readonly Action action;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="caption">The text shown to the user.</param>
        /// <param name="action">The action to run when the item is chosen.</param>
        public MenuItem(string caption, Action action)
        {
            this.caption = caption;
            this.action = action;
        }

        /// <summary>
        /// Gets the text shown to the user.
        /// </summary>
        public string Caption
        {
            get { return this.caption; }
        }

        /// <summary>
        /// Gets the action to run when the item is chosen.
        /// </summary>
        public Action Action
        {
            get { return this.action; }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.caption;
        }
    }
}
