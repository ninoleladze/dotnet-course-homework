using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Counter
    {
        public int count;

        public void Increment()
        {
            count++;
        }
        public void Decrement()
        {
            count--;
        }
        public void Reset()
        {
            count = 0;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
