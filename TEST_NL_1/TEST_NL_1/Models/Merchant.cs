using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_NL_1.Models
{
    internal class Merchant
    {
        public string Name;
        public string City;
        public int Gold;
        public int ItemCount;

        public void DisplayMerchant()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name:       {Name}");
            Console.WriteLine($"City:       {City}");
            Console.WriteLine($"Gold:       {Gold}");
            Console.WriteLine($"Items:      {ItemCount}");
            Console.WriteLine("");
        }
    }
}
