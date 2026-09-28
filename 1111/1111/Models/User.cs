using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111.Models
{
    internal class User
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public User()=> Id = _count++;

        public override string ToString()
        {
           return $"Id={Id}, name: {Name}, email: {Email}, password: {Password}";
        }

    }
}
