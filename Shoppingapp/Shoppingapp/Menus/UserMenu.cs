using ShoppingApp.Services.Users;

namespace ShoppingApp.Menus
{
    internal static class UserMenu
    {
        private static readonly IUserServices _userServices = new UserServices();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Show Profile");
                Console.WriteLine("0. Back");

                string? choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1": _userServices.Register(); break;
                        case "2": _userServices.Login(); break;
                        case "3": _userServices.Logout(); break;
                        case "4": _userServices.ShowProfile(); break;
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