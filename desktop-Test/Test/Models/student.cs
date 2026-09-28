using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
   public class student
    {

        private static int _count = 1;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }



        public student() => Id = _count++;

        public override string ToString()
        {
            return $"Id={Id}, name: {FirstName} {LastName}, email: {Email}, age: {Age}";
        }
    }
}
