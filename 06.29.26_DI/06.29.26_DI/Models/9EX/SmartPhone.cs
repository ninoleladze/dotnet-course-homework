using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._9EX
{
    public class SmartPhone : Phone
    {
        private string _os;

        public string OS
        {
            get { return _os; }
            set { _os = value; }
        }

        public void InstallApp()
        {
            Console.WriteLine("App installed");
        }
    }
}
