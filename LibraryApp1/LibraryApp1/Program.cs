
using LibraryApp1.Data;
using LibraryApp1.Menus;

DataContext DC = new DataContext();

BookMenu BM = new BookMenu();
UserMenu UM = new UserMenu();
BorrowMenu BrM = new BorrowMenu();
while (true)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. User Menu");
        Console.WriteLine("2. Book Menu");
        Console.WriteLine("3. Borrow Menu");
        Console.WriteLine("4. Exit");
        Console.Write("Select an option: ");
        Console.ResetColor();
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                UM.Show();
                break;
            case "2":
                BM.Show();
                break;
            case "3":
                BrM.Show();
                break;
            case "4":
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