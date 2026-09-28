using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Models
{
    internal class LibraryBook
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Pages;
        public int PublishedYear;
        public bool IsAvailable;

        public void DisplayBook()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Title:      {Title}");
            Console.WriteLine($"Author:     {Author}");
            Console.WriteLine($"Genre:      {Genre}");
            Console.WriteLine($"Pages:      {Pages}");
            Console.WriteLine($"Year:       {PublishedYear}");
            Console.WriteLine($"Available:  {IsAvailable}");
            Console.WriteLine("");
        }
    }
}
