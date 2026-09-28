using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._8EX
{
    public class Shape
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Describe()
        {
            Console.WriteLine("I am a shape");
        }
    }
}
