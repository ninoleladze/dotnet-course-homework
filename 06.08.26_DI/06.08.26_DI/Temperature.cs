using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Temperature
    {
        public double celsius;

        public double ToFahrenheit()
        {
            return (celsius * 9 / 5) + 32;
        }
        public bool IsFreezing()
        {
            return celsius <= 0;
        }
    }
}
