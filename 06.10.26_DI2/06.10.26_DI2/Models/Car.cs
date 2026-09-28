using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Models
{
    internal class Car
    {
        public string Brand;
        public string Model;
        public int Year;
        public decimal Price;
        public int MaxSpeedKmh;
        public bool IsNew;

        public void DisplayCar()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Brand:      {Brand}");
            Console.WriteLine($"Model:      {Model}");
            Console.WriteLine($"Year:       {Year}");
            Console.WriteLine($"Price:      {Price} $");
            Console.WriteLine($"Max Speed:  {MaxSpeedKmh} km/h");
            Console.WriteLine($"Is New:     {IsNew}");
            Console.WriteLine("");
        }
    }
}
