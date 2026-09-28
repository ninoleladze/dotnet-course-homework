using LibraryApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Models
{
    internal class Borrow
    {
  
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnedAt { get; set; }
        public BorrowStatus Status { get; set; } = BorrowStatus.Active;
        public User User { get; set; }
        public Book Book { get; set; }


        public override string ToString()
        {
            return $"Borrow Id: {Id}, User Id: {UserId}, Book Id: {BookId}, Borrowed At: {BorrowedAt}, Returned At: {ReturnedAt?.ToString() ?? "Not Returned"}, Status: {Status}";
        }



    }
}
