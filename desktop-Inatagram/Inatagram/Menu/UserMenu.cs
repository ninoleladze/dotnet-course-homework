using Inatagram.Services;

namespace Inatagram.Menu
{
    internal class UserMenu
    {
        private static UsersService _usersService = new UsersService();

        public static void Start()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Logout");
                    Console.WriteLine("4. Profile");
                    Console.WriteLine("5. Edit profile");
                    Console.WriteLine("6. Delete profile");
                    Console.WriteLine("x. Exit");

                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();

                    if (key == "1")
                    {
                        Console.Clear();
                        _usersService.Register();
                    }
                    else if (key == "2")
                    {
                        Console.Clear();
                        _usersService.Login();
                    }
                    else if (key == "3")
                    {
                        Console.Clear();
                        _usersService.Logout();
                    }
                    else if (key == "4")
                    {
                        Console.Clear();
                        _usersService.ViewProfile();
                    }
                    else if (key == "5")
                    {
                        Console.Clear();
                        _usersService.EditProfile();
                    }
                    else if (key == "6")
                    {
                        Console.Clear();
                        _usersService.DeleteProfile();
                    }
                    else if (key == "x")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid key.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
