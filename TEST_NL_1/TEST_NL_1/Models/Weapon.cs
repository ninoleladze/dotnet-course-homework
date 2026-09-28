using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Weapon
    {
        public string Name;
        public int Damage;
        public int Price;
        public string Type;

        public void DisplayWeapon()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Weapon:     {Name}");
            Console.WriteLine($"Damage:     {Damage}");
            Console.WriteLine($"Price:      {Price} Gold");
            Console.WriteLine($"Type:       {Type}");
        }
    }
}
