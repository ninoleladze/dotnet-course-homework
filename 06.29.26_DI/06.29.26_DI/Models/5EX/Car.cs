using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._5EX
{
    public class Car : Vehicle
    {
        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public void Drive()
        {
            Console.WriteLine("Driving " + Brand + " " + Model);
        }
    }
}
