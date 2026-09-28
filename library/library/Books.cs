using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class Books
    {
        private static int _counter = 1;
        public int BookId { get; set; }
        public string Title { get; set; }
       public string Author { get; set; }

        public Books()
        {
            BookId = _counter++;
        }


        public override string ToString()
        {
            return $"BookId: {BookId}, Title: {Title}, Author: {Author}";
        }
    }
}
