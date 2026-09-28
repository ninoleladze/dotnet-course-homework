using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._7EX
{
    public class Manager : Employee
    {
        private int _teamSize;

        public int TeamSize
        {
            get { return _teamSize; }
            set { _teamSize = value; }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Manager: {Name}, Salary: {Salary}, Team Size: {TeamSize}");
        }
    }
}
