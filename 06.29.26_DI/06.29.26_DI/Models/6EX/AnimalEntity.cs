using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._6EX
{
    public class AnimalEntity : LivingThing
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
