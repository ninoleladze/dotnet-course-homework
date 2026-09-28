using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._6EX
{
    public class Cat : AnimalEntity
    {
        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
