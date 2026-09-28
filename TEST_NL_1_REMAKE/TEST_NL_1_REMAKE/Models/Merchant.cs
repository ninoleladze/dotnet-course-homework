using System;

namespace TEST_NL_1_REMAKE.Models
{
    internal class Merchant
    {
        private string name;
        private int gold;
        private int itemCount;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; else Console.WriteLine("Error: Merchant name is required."); }
        }

        public string City { get; set; }

        public int Gold
        {
            get { return gold; }
            set { if (value >= 0) gold = value; else Console.WriteLine("Error: Gold cannot be negative."); }
        }

        public int ItemCount
        {
            get { return itemCount; }
            set { if (value >= 0) itemCount = value; else Console.WriteLine("Error: Item count cannot be less than zero."); }
        }

        public void DisplayMerchant() => Console.WriteLine($"Merchant: {Name} | City: {City} | Gold: {Gold} | Items: {ItemCount}");
    }
}