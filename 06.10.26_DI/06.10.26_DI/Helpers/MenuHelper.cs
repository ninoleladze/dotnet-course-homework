using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI.Helpers
{
    internal class MenuHelper
    {
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Product App!");
            Console.WriteLine("1. view all products");
            Console.WriteLine("2. view products(sorted by price) ascending");
            Console.WriteLine("3. view products(sorted by price) descending");
            Console.WriteLine("4. view only new products");
            Console.WriteLine("0. exit");
            Console.ResetColor();
        }
        public string AskUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose an option:");
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
        }
    }
}
