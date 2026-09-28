using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEn.Models
{
    internal class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; } = false;

        public override string ToString()
        {
          return $"ID: {Id}, Title: {Title}, Author: {Author}, IsBorrowed: {IsBorrowed}";
        }

    }
}
