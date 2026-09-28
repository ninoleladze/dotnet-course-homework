using ShoppingApp.Menus;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== Shopping App ===");
            Console.WriteLine("1. User Menu");
            Console.WriteLine("2. Product Menu");
            Console.WriteLine("3. Order Menu");
            Console.WriteLine("0. Exit");

            string? choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1": UserMenu.Show(); break;
                    case "2": ProductMenu.Show(); break;
                    case "3": OrderMenu.Show(); break;
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