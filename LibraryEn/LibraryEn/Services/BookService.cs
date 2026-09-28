using LibraryEn.Models;
using System;
using System.Linq;

namespace LibraryEn.Services
{
    internal class BookService
    {
        private Baza baza = new Baza();

        public void CreateBook()
        {
            Console.WriteLine("Enter Book title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Book author: ");
            string author = Console.ReadLine();

            var book = new Book()
            {
                Title = title,
                Author = author
            };

            baza.Books.Add(book);
            baza.SaveChanges();
            Console.WriteLine("Book created successfully!");
        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter Book ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = baza.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    baza.Books.Remove(book);
                    baza.SaveChanges();
                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public void UpdateBook()
        {
            Console.WriteLine("Enter Book ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = baza.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    Console.WriteLine($"Current Title: {book.Title}");
                    Console.WriteLine("Enter new Title (leave empty to keep current): ");
                    string newTitle = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                        book.Title = newTitle;

                    Console.WriteLine($"Current Author: {book.Author}");
                    Console.WriteLine("Enter new Author (leave empty to keep current): ");
                    string newAuthor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAuthor))
                        book.Author = newAuthor;

                    baza.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public void GetBooks()
        {
            var books = baza.Books.ToList();
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            Console.WriteLine("Books in library:");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

       
    }
}