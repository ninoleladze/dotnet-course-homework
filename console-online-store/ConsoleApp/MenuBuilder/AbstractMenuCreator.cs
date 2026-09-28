using StoreDAL.Data;

namespace ConsoleMenu.Builder;

/// <summary>
/// Base class for role-specific main menu builders: subclasses only need to list their entries.
/// </summary>
public abstract class AbstractMenuCreator : IMenuCreator
{
    /// <summary>
    /// Gets the hotkey/caption/action entries for this role's main menu.
    /// </summary>
    /// <param name="context">The shared database context.</param>
    /// <returns>The menu entries.</returns>
    public abstract (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context);

    /// <inheritdoc/>
    public Menu Create(StoreDbContext context)
    {
        return new Menu(this.GetMenuItems(context));
    }
}
