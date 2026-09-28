using _1._16.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._16.Models
{
    internal class UserDetails
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
        public UserGender? Gender { get; set; }
        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }

        

    }
}
