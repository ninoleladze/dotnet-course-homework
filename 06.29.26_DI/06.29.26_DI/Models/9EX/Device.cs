using System;
using System.Collections.Generic;
using System.Text;

namespace _06._29._26_DI.Models._9EX
{
    public class Device
    {
        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public void PowerOn()
        {
            Console.WriteLine("Device on");
        }
    }
}
