using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class BookCart
    {
        public static int _counter = 1;

        public int Id { get; set; }
       public int quantity { get; set; }
        public Books books { get; set; }

        public BookCart()
        {
            Id = _counter++;
        }
        public override string ToString()
        {
            return $" {Id}- {books.Title}- {books.Author}  ";
        }

    }
}
