using _1._16.Common;
using _1._16.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1._16.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public UserRoles Role { get; set; } = UserRoles.User;
        public UserDetails Details { get; set; }


    }
}
