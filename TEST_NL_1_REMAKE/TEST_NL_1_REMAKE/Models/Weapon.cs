using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Weapon
    {
        private string name;
        private int damage;
        private int price;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; else Console.WriteLine("Error: Weapon name cannot be empty."); }
        }

        public int Damage
        {
            get { return damage; }
            set { if (value >= 0) damage = value; else Console.WriteLine("Error: Damage cannot be negative."); }
        }

        public int Price
        {
            get { return price; }
            set { if (value >= 0) price = value; else Console.WriteLine("Error: Price cannot be negative."); }
        }

        public string Type { get; set; }

        public void DisplayWeapon() => Console.WriteLine($"Weapon: {Name} | Damage: {Damage} | Price: {Price} Gold | Type: {Type}");
    }
}