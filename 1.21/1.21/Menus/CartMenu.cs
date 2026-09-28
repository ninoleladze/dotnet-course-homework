using _1._21.Services;
using System;

namespace _1._21.Menus
{
    internal class CartMenu
    {
        private CartServices cartServices = new CartServices();

        public void ShowCartMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("=== Cart Menu ===");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Add to Cart");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. Remove from Cart");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("3. Update Cart Item");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("4. Show Cart");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5. Exit");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nSelect an option: ");
                    Console.ResetColor();

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.ResetColor();
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            cartServices.AddToCart();
                            break;
                        case 2:
                            cartServices.RemoveFromCart();
                            break;
                        case 3:
                            cartServices.UpdateCart();
                            break;
                        case 4:
                            cartServices.ShowUserCart();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Returning to main menu...");
                            Console.ResetColor();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}