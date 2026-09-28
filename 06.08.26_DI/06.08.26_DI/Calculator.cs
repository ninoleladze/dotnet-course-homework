using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return 0;
            }
        }
    }
}
