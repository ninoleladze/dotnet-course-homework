using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._7EX
{
    public class Employee
    {
        private string _name;
        private double _salary;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
