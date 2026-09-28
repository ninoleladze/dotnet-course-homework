using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _624
{
    internal class Class1
    { 


        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Price { get; set; }


        public Class1(string? title, string? author, int price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
        public void printInfo()
        {
            Console.WriteLine($"Title{Title}, Author{Author},Price{Price}");
        }


    }
}
