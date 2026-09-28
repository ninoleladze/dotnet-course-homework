using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class NumberBox
    {
        public List<int> numbers = new List<int>();

        public void AddNumber(int number)
        {
            numbers.Add(number);
        }
        public int GetSum()
        {
            return numbers.Sum();
        }
        public int GetMax()
        {
            return numbers.Max();
        }
        public void PrintAll()
        {
            foreach (int number in numbers)
            {

                Console.WriteLine(number);
            }
        }
    }
}
