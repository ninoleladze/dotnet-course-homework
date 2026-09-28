using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._24._26.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserDetails Details { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public List<Order> Orders { get; set; } = new List<Order>();


    }
}
