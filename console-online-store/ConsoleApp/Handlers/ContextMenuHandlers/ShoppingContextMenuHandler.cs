using System;
using System.Globalization;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreBLL.Services;

namespace ConsoleApp.Handlers.ContextMenuHandlers;

/// <summary>
/// Lets a registered customer browse products and place a single-item order for the currently
/// signed-in user.
/// </summary>
public class ShoppingContextMenuHandler : ContextMenuHandler
{
    private readonly CustomerOrderService orderService;
    private readonly Func<int> currentUserId;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShoppingContextMenuHandler"/> class.
    /// </summary>
    /// <param name="service">The product catalog service backing the "View Details" action.</param>
    /// <param name="readModel">Unused by this handler; kept for compatibility with the base menu framework.</param>
    /// <param name="orderService">The service used to place the order.</param>
    /// <param name="currentUserId">Resolves the identifier of the customer placing the order.</param>
    public ShoppingContextMenuHandler(ICrud service, Func<AbstractModel> readModel, CustomerOrderService orderService, Func<int> currentUserId)
        : base(service, readModel)
    {
        this.orderService = orderService;
        this.currentUserId = currentUserId;
    }

    /// <summary>
    /// Prompts for a product id and quantity and places a new order for it.
    /// </summary>
    public void CreateOrder()
    {
        Console.WriteLine("Input Product Id to order");
        var productId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input quantity");
        var amount = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);

        try
        {
            var order = this.orderService.CreateOrder(this.currentUserId(), new[] { (productId, amount) });
            Console.WriteLine("Order placed: " + order);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Could not place order: " + ex.Message);
        }
    }

    /// <inheritdoc/>
    public override (ConsoleKey id, string caption, Action action)[] GenerateMenuItems()
    {
        (ConsoleKey id, string caption, Action action)[] array =
            {
                 (ConsoleKey.V, "View Details", this.GetItemDetails),
                 (ConsoleKey.A, "Add item to chart and create order", this.CreateOrder),
            };
        return array;
    }
}
