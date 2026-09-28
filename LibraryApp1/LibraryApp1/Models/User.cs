using LibraryApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.Member;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();

        public override string ToString()
        {
            return $"{FullName} ({Email}) - Role: {Role}";
        }
    }
}
