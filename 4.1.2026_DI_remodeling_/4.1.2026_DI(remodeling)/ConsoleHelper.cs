using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1._2026_DI_remodeling_
{
    public static class ConsoleHelper
    {
        public static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintSuccess(string message) => PrintColored(message, ConsoleColor.Green);
        public static void PrintError(string message) => PrintColored(message, ConsoleColor.Red);
        public static void PrintWarning(string message) => PrintColored(message, ConsoleColor.DarkYellow);

        public static string AskInput(string prompt, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.Write(prompt);
            Console.ResetColor();
            return Console.ReadLine()?.Trim();
        }

        public static bool TryGetAmount(string prompt, out decimal amount)
        {
            if (!decimal.TryParse(AskInput(prompt), out amount) || amount <= 0)
            {
                PrintError("  Invalid amount. Must be greater than 0.");
                return false;
            }
            return true;
        }

        public static string ChooseCurrency()
        {
            string input = AskInput("Currency (1 = GEL, 2 = USD) [default: GEL]: ", ConsoleColor.DarkGray);
            return input == "2" ? "USD" : "GEL";
        }
    }
}
