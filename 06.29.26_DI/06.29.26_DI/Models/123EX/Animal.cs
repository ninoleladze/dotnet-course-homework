using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._1EX
{
    public class Animal
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Eat()
        {
            Console.WriteLine("This animal is eating");
        }
    }
}
