using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backnew111hm
{
    internal class Person
    {
        protected int age;

        public void SetAge(int age)
        {
            this.age = age;
            
        }

        public void SayHello()
        {
            Console.WriteLine("hello");
        }
    }
}
