namespace ConsoleApp.Services;
using System;
using System.Globalization;
using ConsoleApp.Handlers.ContextMenuHandlers;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;

/// <summary>
/// Presentation-layer actions for managing users, user roles, and a signed-in user's own profile.
/// </summary>
public static class UserController
{
    private static StoreDbContext context = UserMenuController.Context;

    /// <summary>
    /// Lets a guest self-register as a new "Registered" user.
    /// </summary>
    public static void RegisterUser()
    {
        Console.WriteLine("=== Register a new account ===");
        Console.WriteLine("First name:");
        var name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Last name:");
        var lastName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Login:");
        var login = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Password:");
        var password = Console.ReadLine() ?? string.Empty;

        var service = new UserService(context);
        try
        {
            var user = service.Register(name, lastName, login, password);
            Console.WriteLine($"Registration successful. Welcome, {user.Name}! You can now login with your credentials.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Registration failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Lets the currently signed-in user update their own name, last name and login.
    /// </summary>
    public static void UpdateOwnProfile()
    {
        var service = new UserService(context);
        var current = (UserModel)service.GetById(UserMenuController.CurrentUserId);

        Console.WriteLine($"First name [{current.Name}]:");
        var name = Console.ReadLine();
        Console.WriteLine($"Last name [{current.LastName}]:");
        var lastName = Console.ReadLine();
        Console.WriteLine($"Login [{current.Login}]:");
        var login = Console.ReadLine();

        var updated = new UserModel(
            current.Id,
            string.IsNullOrWhiteSpace(name) ? current.Name : name,
            string.IsNullOrWhiteSpace(lastName) ? current.LastName : lastName,
            string.IsNullOrWhiteSpace(login) ? current.Login : login,
            string.Empty,
            current.RoleId);
        service.Update(updated);
        Console.WriteLine("Profile updated.");
    }

    /// <summary>
    /// Opens the full add/remove/edit/view menu for all users. Administrator-only.
    /// </summary>
    public static void ShowAllUsers()
    {
        var service = new UserService(context);
        var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadUserModel), service.GetAll);
        menu.Run();
    }

    /// <summary>
    /// Opens the full add/remove/edit/view menu for all user roles. Administrator-only.
    /// </summary>
    public static void ShowAllUserRoles()
    {
        var service = new UserRoleService(context);
        var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadUserRoleModel), service.GetAll);
        menu.Run();
    }
}
