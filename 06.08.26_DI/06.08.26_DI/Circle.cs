using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Circle
    {
        public double radius;
        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public double GetCircumference()
        {
            return 2 * Math.PI * radius;
        }
    }
}
