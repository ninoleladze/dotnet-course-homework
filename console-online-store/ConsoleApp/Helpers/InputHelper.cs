namespace ConsoleApp.Helpers;
using System;
using System.Globalization;
using StoreBLL.Models;

/// <summary>
/// Reads console input and turns it into BLL model instances for admin add/edit menu actions.
/// </summary>
internal static class InputHelper
{
    /// <summary>
    /// Reads a <see cref="CategoryModel"/> (id + name) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static CategoryModel ReadCategoryModel()
    {
        Console.WriteLine("Input Category Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Category Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new CategoryModel(id, name);
    }

    /// <summary>
    /// Reads a <see cref="ManufacturerModel"/> (id + name) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static ManufacturerModel ReadManufacturerModel()
    {
        Console.WriteLine("Input Manufacturer Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Manufacturer Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new ManufacturerModel(id, name);
    }

    /// <summary>
    /// Reads a <see cref="ProductTitleModel"/> (id, title, category id) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static ProductTitleModel ReadProductTitleModel()
    {
        Console.WriteLine("Input Product Title Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Product Title");
        var title = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(title);
        Console.WriteLine("Input Category Id");
        var categoryId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        return new ProductTitleModel(id, title, categoryId);
    }

    /// <summary>
    /// Reads a <see cref="ProductModel"/> (id, title id, manufacturer id, price, description) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static ProductModel ReadProductModel()
    {
        Console.WriteLine("Input Product Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Product Title Id");
        var titleId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Manufacturer Id");
        var manufacturerId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Unit Price");
        var price = decimal.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input Description");
        var description = Console.ReadLine() ?? string.Empty;
        return new ProductModel(id, titleId, manufacturerId, description, price);
    }

    /// <summary>
    /// Reads a <see cref="UserModel"/> (id, name, last name, login, password, role id) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static UserModel ReadUserModel()
    {
        Console.WriteLine("Input User Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input First Name");
        var name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Input Last Name");
        var lastName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Input Login");
        var login = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Input Password");
        var password = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Input User Role Id");
        var roleId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        return new UserModel(id, name, lastName, login, password, roleId);
    }

    /// <summary>
    /// Reads an <see cref="OrderStateModel"/> (id + state name) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static OrderStateModel ReadOrderStateModel()
    {
        Console.WriteLine("Input State Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new OrderStateModel(id, name);
    }

    /// <summary>
    /// Reads a <see cref="UserRoleModel"/> (id + role name) from the console.
    /// </summary>
    /// <returns>The model built from console input.</returns>
    public static UserRoleModel ReadUserRoleModel()
    {
        Console.WriteLine("Input User Role Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input User Role Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new UserRoleModel(id, name);
    }
}
