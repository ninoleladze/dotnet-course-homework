using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._20.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        override public string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Email: {Email}, Posts Count: {Posts?.Count ?? 0}";
        }
    }
}
