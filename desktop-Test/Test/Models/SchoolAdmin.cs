using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SchoolAdmin
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public SchoolAdmin() => Id = _count++;

        public override string ToString()
        {

            return $"Id={Id}, username: {Username}, password: {Password}";
        }

        }
}
