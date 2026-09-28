using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Person
    {
        public string name;
        public int age;


        public bool IsAdult()
        {
            return age >= 18;
        }

        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
        }
    }
}
