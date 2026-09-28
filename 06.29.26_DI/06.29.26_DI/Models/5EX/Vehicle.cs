using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._5EX
{
    public class Vehicle
    {
        private string _brand;
        private double _speed;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    }
}
