using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

/// <summary>
/// The main menu for a signed-in administrator: manage the catalog, users, roles, order states, and
/// order statuses.
/// </summary>
public class AdminMainMenu : AbstractMenuCreator
{
    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.F1, "Logout", UserMenuController.Logout),
                (ConsoleKey.F2, "Show product list", ProductController.ShowAllProducts),
                (ConsoleKey.F3, "Manage products", ProductController.ManageProducts),
                (ConsoleKey.F4, "Manage categories", ProductController.ManageCategories),
                (ConsoleKey.F5, "Manage product titles", ProductController.ManageProductTitles),
                (ConsoleKey.F6, "Manage manufacturers", ProductController.ManageManufacturers),
                (ConsoleKey.F7, "User roles", UserController.ShowAllUserRoles),
                (ConsoleKey.F8, "Order states", ShopController.ShowAllOrderStates),
                (ConsoleKey.F9, "Manage users", UserController.ShowAllUsers),
                (ConsoleKey.F10, "Show all orders", ShopController.ShowAllOrders),
                (ConsoleKey.F11, "Change order status", ShopController.ChangeOrderStatus),
            };
        return array;
    }
}
