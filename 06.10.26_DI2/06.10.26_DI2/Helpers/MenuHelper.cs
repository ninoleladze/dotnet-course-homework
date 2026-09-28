using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Helpers
{
    internal class MenuHelper
    {
        public void ShowMenu()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=================================");
            Console.WriteLine("        MAIN MENU                ");
            Console.WriteLine("=================================");
            Console.WriteLine("--- LIBRARY ---");
            Console.WriteLine(" 1. View all books");
            Console.WriteLine(" 2. View available books");
            Console.WriteLine(" 3. Search books by genre");
            Console.WriteLine(" 4. View books sorted by pages (ascending)");
            Console.WriteLine(" 5. View books published after 2000");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--- CARS ---");
            Console.WriteLine(" 6. View all cars");
            Console.WriteLine(" 7. View new cars only");
            Console.WriteLine(" 8. View cars sorted by price (ascending)");
            Console.WriteLine(" 9. Search cars by brand");
            Console.WriteLine("10. View cars with max speed over 200 km/h");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- STUDENTS ---");
            Console.WriteLine("11. View all students");
            Console.WriteLine("12. View students sorted by GPA (descending)");
            Console.WriteLine("13. View active students only");
            Console.WriteLine("14. Search students by faculty");
            Console.WriteLine("15. View students with GPA above 3.5");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" 0. Exit");
            Console.ResetColor();
        }

        public string AskUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Choose an option: ");
            string archevani = Console.ReadLine();
            Console.ResetColor();
            return archevani;
        }

        public void Wait()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
