using LibraryApp1.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Menus
{
    internal class UserMenu
    {
        UserService userService = new UserService();
        public void Show()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("User Menu:");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Logout");
                    Console.WriteLine("4. Profile");
                    Console.WriteLine("5. Exit");
                    Console.Write("Select an option: ");
                    Console.ResetColor();
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            userService.Register();
                            break;
                        case "2":
                            userService.Login();
                            break;
                        case "3":
                            userService.logout();
                            break;
                        case "4":
                            userService.ShowProfile();
                            break;
                        case "5":
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
