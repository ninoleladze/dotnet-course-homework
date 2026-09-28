using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._2EX
{
    public class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
