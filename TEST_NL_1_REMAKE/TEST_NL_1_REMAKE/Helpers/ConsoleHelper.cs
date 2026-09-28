using System;

namespace TEST_NL_1_REMAKE.Helpers
{
    internal class ConsoleHelper
    {
        public void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("           FANTASY RPG MANAGER            ");
            Console.WriteLine("==========================================");
            Console.ResetColor();
            Console.WriteLine("  1. gmirebi          (Heroes)");
            Console.WriteLine("  2. iaraghebi        (Weapons)");
            Console.WriteLine("  3. wamlebi          (Potions)");
            Console.WriteLine("  4. urchxulebi       (Monsters)");
            Console.WriteLine("  5. davalebebi       (Quests)");
            Console.WriteLine("  6. vacrebi          (Merchants)");
            Console.WriteLine("  7. statistika       (Global Stats)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  0. gasvla");
            Console.ResetColor();
            Console.WriteLine("==========================================");
        }

        public string AskUser(string message = "airchie menu (0-7): ")
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void Wait()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void PrintError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option. Please try again.");
            Console.ResetColor();
            Wait();
        }
    }
}