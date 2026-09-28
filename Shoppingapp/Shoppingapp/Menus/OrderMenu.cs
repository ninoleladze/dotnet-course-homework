using ShoppingApp.Services.Orders;

namespace ShoppingApp.Menus
{
    internal static class OrderMenu
    {
        private static readonly IOrderServices _orderServices = new OrderServices();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- Order Menu ---");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. Checkout");
                Console.WriteLine("3. View Orders");
                Console.WriteLine("0. Back");

                string? choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1": _orderServices.AddToCart(); break;
                        case "2": _orderServices.Checkout(); break;
                        case "3": _orderServices.ViewOrders(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}