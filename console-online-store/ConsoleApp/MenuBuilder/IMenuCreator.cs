/*
Yuriy Antonov copyright 2018-2020
*/
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

/// <summary>
/// Builds the top-level <see cref="Menu"/> shown for a given user role.
/// </summary>
public interface IMenuCreator
{
    /// <summary>
    /// Builds the menu.
    /// </summary>
    /// <param name="context">The shared database context.</param>
    /// <returns>The built menu.</returns>
    Menu Create(StoreDbContext context);
}
