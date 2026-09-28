using _06._10._26_DI2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Services
{
    internal class LibraryService
    {
        public void ShowAllBooks(List<LibraryBook> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                books[i].DisplayBook();
            }
        }

        public void ShowAvailableBooks(List<LibraryBook> books)
        {
            List<LibraryBook> available = books.Where(b => b.IsAvailable == true).ToList();
            ShowAllBooks(available);
        }

        public void SearchByGenre(List<LibraryBook> books)
        {
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            List<LibraryBook> filtered = books.Where(b => b.Genre.ToLower() == genre.ToLower()).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine("No books found for this genre.");
                return;
            }
            ShowAllBooks(filtered);
        }

        public void ShowBooksSortedByPages(List<LibraryBook> books)
        {
            List<LibraryBook> sorted = books.OrderBy(b => b.Pages).ToList();
            ShowAllBooks(sorted);
        }

        public void ShowBooksPublishedAfter2000(List<LibraryBook> books)
        {
            List<LibraryBook> recent = books.Where(b => b.PublishedYear > 2000).ToList();
            ShowAllBooks(recent);
        }
    }
}