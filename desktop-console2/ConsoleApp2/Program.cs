using ConsoleApp2;

UserService userService = new UserService();

userService.LoadUsers();

// TODO: უკვე არსებული მეილით თუ შემოიყვანა 
// კონსლში გამოიტანოს რომ უკვე არსებობს

// TODO: დაამატეთ EditUser ის ფუქნცია
// უნდა შეეძლოს Username-ის განახლებე თუ დალოგინებულია

// TODO: დაამატეთ პაროლის განახლების სისტემა
// უნდა შემოიყვანოს მეილი, ძველი პაროლი, ახალი პაროლი
// თუ დალოგინებულია უნდა განუახლდეს პაროლი


while (true)
{
    Console.WriteLine("========== Authorization =============");
    Console.WriteLine("1. register");
    Console.WriteLine("2. login");
    Console.WriteLine("3. show users");
    Console.WriteLine("4. logout");
    Console.WriteLine("5. show logged in user");

    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        userService.Register();
    }
    else if (key == "2")
    {
        Console.Clear();
        userService.Login();
    }
    else if (key == "3")
    {
        Console.Clear();
        userService.ShowUsers();
    }
    else if (key == "4")
    {
        Console.Clear();
        userService.Logout();
    }
    else if (key == "5")
    {
        Console.Clear();
        userService.ShowLoggedInUser();
    }
    else break;
}