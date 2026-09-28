using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nini
{
    internal class Library
    {

        public void AddBook(string title, string author)
        {
          
            Console.WriteLine($"Book '{title}' by {author} added to the library.");
        }

    }
}
