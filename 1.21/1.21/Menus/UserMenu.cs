using _1._21.Services;
using System;

namespace _1._21.Menus
{
    internal class UserMenu
    {
        private UserServices userServices = new UserServices();

        public void ShowUserMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("=== User Menu ===");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Register");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. Login");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("3. Logout");
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
                            userServices.Register();
                            break;
                        case 2:
                            userServices.Login();
                            break;
                        case 3:
                            userServices.logout();
                            break;
                        case 4:
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