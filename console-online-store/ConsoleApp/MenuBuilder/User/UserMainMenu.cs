using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

/// <summary>
/// The main menu for a signed-in registered customer: browse and order products, manage their own
/// orders, and edit their profile.
/// </summary>
public class UserMainMenu : AbstractMenuCreator
{
    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                (ConsoleKey.F1, "Logout", UserMenuController.Logout),
                (ConsoleKey.F2, "Show product list", ProductController.ShowAllProducts),
                (ConsoleKey.F3, "Create order", ShopController.CreateOrder),
                (ConsoleKey.F4, "Show my orders", ShopController.ShowMyOrders),
                (ConsoleKey.F5, "Cancel my order", ShopController.CancelMyOrder),
                (ConsoleKey.F6, "Confirm order delivery received", ShopController.ConfirmMyOrderDelivery),
                (ConsoleKey.F7, "Change personal information", UserController.UpdateOwnProfile),
            };
        return array;
    }
}