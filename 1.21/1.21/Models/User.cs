using _1._21.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._21.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; } = UserRoles.User;
        public List<CartItem> CartItems { get; set; }=new List<CartItem>();


        public override string ToString()
        {
            return $"ID: {Id}, Username: {Username}, Email: {Email}, Role: {Role}";
        }



    }
}
