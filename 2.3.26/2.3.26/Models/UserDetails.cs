using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._26.Models
{
    internal class UserDetails
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
