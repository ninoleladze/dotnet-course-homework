using ConsoleApp.Controllers;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreDAL.Data;

namespace ConsoleMenu.Builder;

/// <summary>
/// The main menu for an unauthenticated visitor: browse products, log in, or register.
/// </summary>
public class GuestMainMenu : AbstractMenuCreator
{
    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GetMenuItems(StoreDbContext context)
    {
        (ConsoleKey id, string caption, Action action)[] array =
        {
            (ConsoleKey.F1, "Login", UserMenuController.Login),
            (ConsoleKey.F2, "Show product list", ProductController.ShowAllProducts),
            (ConsoleKey.F3, "Register", UserController.RegisterUser),
        };
        return array;
    }
}