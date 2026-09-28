using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Hero
    {
        public string Name;
        public string HeroClass;
        public int Level;
        public int Health;

        public void DisplayHero()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name:       {Name}");
            Console.WriteLine($"Class:      {HeroClass}");
            Console.WriteLine($"Level:      {Level}");
            Console.WriteLine($"Health:     {Health}");
        }
    }
}
