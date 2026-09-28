using Amazon.Menus;
using Amazon.Services.Users;

while (true)
{
    Console.WriteLine("1. user menu");
    Console.WriteLine("2. products menu");

    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        UserMenu.Start();
    }
    else if (key == "2")
    {
        Console.Clear();

        if (UserServices.IsLoggedIn())
        {
            ProductMenu.Start();
        }
        else
        {
            Console.WriteLine("Unauthorized!");
        }
    }
    else
    {
        Console.WriteLine("Invalid key");
    }
}