using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Rectangle
    {
        public int width;
        public int height;


        public int GetArea()
        {
            return width * height;
        }

        public int GetPerimeter()
        {
            return 2 * (width + height);
        }

    }
}
