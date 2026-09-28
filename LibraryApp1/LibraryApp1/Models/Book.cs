using LibraryApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Models
{
    internal class Book
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        public int Copies { get; set; } = 1;

        public BookStatus Status { get; set; } = BookStatus.Available;
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();

        public override string ToString()
        {
            return $"{Title} by {Author} ({PublishedYear}) - ISBN: {ISBN} - Copies: {Copies} - Status: {Status}";
        }



    }
}
