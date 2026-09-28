using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI.Models
{
    internal class Product
    {
        public string Name;
        public decimal Price;
        public int Stock;
        public bool IsNew;



        public void DisplayProduct()
        {
            Console.WriteLine("displaying product");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Stock: {Stock}");
            Console.WriteLine($"Is New: {IsNew}");
            Console.WriteLine("");
        }
    }
}
