using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backnew111hm
{
    internal class Teacher : Person
    {
        public void Explain()
        {
            Console.WriteLine("I'm explaining.");
        }

        public void ShowAge()
        {
            Console.WriteLine($"My age is: {age}");
        }
    }
}