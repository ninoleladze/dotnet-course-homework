using _1._21.Data;
using _1._21.Menus;
using System;

namespace _1._21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext context = new DataContext();

            UserMenu userMenu = new UserMenu();
            ProductMenu productMenu = new ProductMenu();
            CartMenu cartMenu = new CartMenu();

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("=== Main Menu ===");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. User Menu");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. Product Menu");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("3. Cart Menu");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("4. Exit");
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
                            userMenu.ShowUserMenu();
                            break;
                        case 2:
                            productMenu.ShowProductMenu();
                            break;
                        case 3:
                            cartMenu.ShowCartMenu();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Exiting the application...");
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