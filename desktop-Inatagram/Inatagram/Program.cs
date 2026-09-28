using Inatagram.Menu;
using Inatagram.Services;

while (true)
{
    Console.WriteLine("1. user menu");
    Console.WriteLine("2. post menu");

    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        UserMenu.Start();
    }
    else if (key == "2")
    {
        if (UsersService.LoggedInUser == null)
        {
            Console.WriteLine("Unauthorized.");
        }
        else
        {
            PostMenu.Start();
        }
    }
}