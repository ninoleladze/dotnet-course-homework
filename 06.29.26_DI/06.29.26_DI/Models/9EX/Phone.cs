using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._9EX
{
    public class Phone : Device
    {
        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
