using Ebay.Services.Users;


namespace Ebay.Menus
{
    internal class UserMenu
    {
        private static IUserServices _services = new UserServices();

        public static void Start()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. register");
                    Console.WriteLine("2. login");
                    Console.WriteLine("3. logout");
                    Console.WriteLine("4. show profile");

                    if (UserServices.IsLoggedIn() && UserServices.LoggedInUser!.IsAdmin())
                    {
                        Console.WriteLine("5. promote user to admin");
                    }

                    Console.WriteLine("x. exit");

                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();

                    if (key == "1")
                    {
                        Console.Clear();
                        _services.Register();
                    }
                    else if (key == "2")
                    {
                        Console.Clear();
                        _services.Login();
                    }
                    else if (key == "3")
                    {
                        Console.Clear();
                        _services.Logout();
                    }
                    else if (key == "4")
                    {
                        Console.Clear();
                        _services.ShowProfile();
                    }
                    else if (key == "5")
                    {
                        Console.Clear();

                        if (!UserServices.IsLoggedIn())
                        {
                            Console.WriteLine("You must be logged in to perform this action.");
                        }
                        else if (!UserServices.LoggedInUser!.IsAdmin())
                        {
                            Console.WriteLine("Only admins can promote users.");
                        }
                        else
                        {
                            _services.PromoteToAdmin();
                        }
                    }
                    else if (key == "x")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid key!");
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