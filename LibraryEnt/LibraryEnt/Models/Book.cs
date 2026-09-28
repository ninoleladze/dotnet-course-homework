using LibraryEnt.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEnt.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public int PublishedYear { get; set; }
        public string Genre { get; set; } = null!;
        public BookStatus Status { get; set; } = BookStatus.Available;
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();

        public override string ToString()
        {
            return $"{Title} by {Author} ({PublishedYear}) - Status: {Status}";
        }
    }
}
