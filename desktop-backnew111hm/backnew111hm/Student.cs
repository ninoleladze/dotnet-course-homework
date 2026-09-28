using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backnew111hm
{
    internal class Student : Person
    {
        public void Study()
        {
            Console.WriteLine("I'm studying.");
        }

        public void ShowAge()
        {
            Console.WriteLine($"My age is:{age}");
        }
    }
}

