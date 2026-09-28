using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Potion
    {
        private string name;
        private int price;
        private int quantity;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; else Console.WriteLine("Error: Potion name cannot be empty."); }
        }

        public string Effect { get; set; }

        public int Price
        {
            get { return price; }
            set { if (value >= 0) price = value; else Console.WriteLine("Error: Price cannot be negative."); }
        }

        public int Quantity
        {
            get { return quantity; }
            set { if (value >= 0) quantity = value; else Console.WriteLine("Error: Quantity cannot be less than zero."); }
        }

        public void DisplayPotion() => Console.WriteLine($"Potion: {Name} | Effect: {Effect} | Price: {Price} Gold | Qty: {Quantity}");
    }
}