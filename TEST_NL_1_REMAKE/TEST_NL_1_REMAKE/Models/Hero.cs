using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Hero
    {
        private string name;
        private string heroClass;
        private int level;
        private int health;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; else Console.WriteLine("Error: Hero name cannot be empty."); }
        }

        public string HeroClass
        {
            get { return heroClass; }
            set { if (!string.IsNullOrWhiteSpace(value)) heroClass = value; else Console.WriteLine("Error: Class cannot be empty."); }
        }

        public int Level
        {
            get { return level; }
            set { if (value > 0) level = value; else Console.WriteLine("Error: Level must be greater than 0."); }
        }

        public int Health
        {
            get { return health; }
            set { if (value >= 0) health = value; else Console.WriteLine("Error: Health cannot be negative."); }
        }

        public void DisplayHero() => Console.WriteLine($"Name: {Name} | Class: {HeroClass} | Level: {Level} | Health: {Health}");
    }
}