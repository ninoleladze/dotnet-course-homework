using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Helpers
{
    internal class ConsoleHelper
    {
        public void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==========================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("           FANTASY RPG MANAGER            ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==========================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1. gmirebi          (Heroes)");
            Console.WriteLine("  2. iaraghebi        (Weapons)");
            Console.WriteLine("  3. wamlebi          (Potions)");
            Console.WriteLine("  4. urchxulebi       (Monsters)");
            Console.WriteLine("  5. davalebebi       (Quests)");
            Console.WriteLine("  6. vacrebi          (Merchants)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  7. statistika       (Global Stats)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  0. gasvla");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==========================================");
            Console.ResetColor();
        }

        public string AskUser(string message = "airchie menu (0-7): ")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            string archevani = Console.ReadLine();
            Console.ResetColor();
            return archevani;
        }

        public void Wait()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
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

