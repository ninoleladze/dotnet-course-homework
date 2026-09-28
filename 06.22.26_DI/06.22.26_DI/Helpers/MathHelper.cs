using System;
using System.Collections.Generic;
using System.Text;

namespace _06._22._26_DI.Helpers
{
    internal class MathHelper
    {
        public void Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        }

        public void Add(double a, double b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        }
        public void Add(int a,int b, int c)
        {
            Console.WriteLine($"The sum of {a}, {b}, and {c} is: {a + b + c}");
        }
    }
}
