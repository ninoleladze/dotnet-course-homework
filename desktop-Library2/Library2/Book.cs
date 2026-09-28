using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    internal class Book
    {
        private static int _counter = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public int Year { get; set; }
        public bool IsBorrowed { get; set; } = false;


       
        public Book()
        {
            Id = _counter++;
        }

        public override string ToString()
        {
            return $"id : {Id}, title: {Title}, author:{Author}, year:{Year}, isborrowed: {IsBorrowed} ";
        }

    }
}
