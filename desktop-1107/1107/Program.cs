using _1107;

UserService userService = new UserService();
userService.loadUsers();

while (true)
{
    Console.WriteLine("====autorization=====");
    Console.WriteLine("1. register");
    Console.WriteLine("2. login");
    Console.WriteLine("3. showusers");
    Console.WriteLine("4. logout");
    Console.WriteLine("5. show logged in user");

    Console.WriteLine("enter key");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        userService.register();
    }
    else if (key == "2")
    {
        Console.Clear();
        userService.login();
    }
    else if (key == "3")
    {
        Console.Clear();
        userService.showUsers();
    }
    else if (key == "4")
    {
        Console.Clear();
        userService.logout();
    }
    else if (key == "5") {
        Console.Clear();
        userService.showLoggedInUser();
     }
    else break;

}
























