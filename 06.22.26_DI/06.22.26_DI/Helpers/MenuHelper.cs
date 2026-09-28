using System;
using System.Collections.Generic;
using System.Text;

namespace _06._22._26_DI.Helpers
{
    internal class MenuHelper
    {
        public void ShowMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add two integers");
            Console.WriteLine("2. Add two doubles");
            Console.WriteLine("3. Add three integers");
            Console.WriteLine("4. Exit");
        }

        public void ShowMenu(string menuName)
        {
            Console.WriteLine($"Menu: {menuName}");
            Console.WriteLine("1. Add two integers");
            Console.WriteLine("2. Add two doubles");
            Console.WriteLine("3. Add three integers");
            Console.WriteLine("4. Exit");
        }

        public void ShowMenu(string test,int option)
        {
            Console.WriteLine($"Menu: {test}");
            Console.WriteLine($"Option: {option}");
        }

}
}
