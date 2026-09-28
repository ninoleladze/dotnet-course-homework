using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Potion
    {
        public string Name;
        public string Effect;
        public int Price;
        public int Quantity;

        public void DisplayPotion()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Potion:     {Name}");
            Console.WriteLine($"Effect:     {Effect}");
            Console.WriteLine($"Price:      {Price} Gold");
            Console.WriteLine($"Quantity:   {Quantity}");
        }
    }
}
