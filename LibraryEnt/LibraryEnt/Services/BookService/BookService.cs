using LibraryEnt.Data;
using LibraryEnt.Enums;
using LibraryEnt.Models;
using LibraryEnt.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEnt.Services.BookService
{
    internal class BookService : IBookService
    {
        private DataContext DC = new DataContext();

        public void CreateBook()
        {
            CheckAdmin();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) throw new Exception("Title cannot be empty.");

            Console.WriteLine("Enter author:");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author)) throw new Exception("Author cannot be empty.");

            Console.WriteLine("Enter ISBN:");
            string isbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbn)) throw new Exception("ISBN cannot be empty.");
            if (DC.Books.Any(b => b.ISBN == isbn)) throw new Exception("A book with this ISBN already exists.");

            Console.WriteLine("Enter published year:");
            int year = int.Parse(Console.ReadLine());
            if (year < 1000 || year > DateTime.UtcNow.Year) throw new Exception("Published Year is out of valid range.");

            Console.WriteLine("Enter genre:");
            string genre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(genre)) throw new Exception("Genre cannot be empty.");

            var book = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                PublishedYear = year,
                Genre = genre,
                Status = BookStatus.Available
            };

            DC.Books.Add(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book created successfully.");
            Console.ResetColor();
        }

        public void DeleteBook()
        {
            CheckAdmin();
            GetAllBooks();
            Console.WriteLine("Enter the ID of the book to delete:");
            int bookId = int.Parse(Console.ReadLine());
            var book = DC.Books.Find(bookId);
            if (book == null) throw new Exception("Book not found.");
            DC.Books.Remove(book);
            DC.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book deleted successfully.");
            Console.ResetColor();
        }

        public void UpdateBook()
        {
            CheckAdmin();
            GetAllBooks();
            Console.WriteLine("Enter the ID of the book to update:");
            int bookId = int.Parse(Console.ReadLine());
            var book = DC.Books.Find(bookId);
            if (book == null) throw new Exception("Book not found.");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter new title (leave blank to keep current):");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title)) book.Title = title;

            Console.WriteLine("Enter new author (leave blank to keep current):");
            string author = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(author)) book.Author = author;

            Console.WriteLine("Enter new ISBN (leave blank to keep current):");
            string isbn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(isbn))
            {
                if (DC.Books.Any(b => b.ISBN == isbn && b.Id != book.Id)) throw new Exception("Another book with this ISBN already exists.");
                book.ISBN = isbn;
            }

            Console.WriteLine($"Enter new published year (current: {book.PublishedYear}, leave blank to keep):");
            string yearInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                int year = int.Parse(yearInput);
                if (year < 1000 || year > DateTime.UtcNow.Year) throw new Exception("Published Year is out of valid range.");
                book.PublishedYear = year;
            }

            Console.WriteLine("Enter new genre (leave blank to keep current):");
            string genre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genre)) book.Genre = genre;

            DC.Books.Update(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book updated successfully.");
            Console.ResetColor();
        }

        public void GetAllBooks()
        {
            CheckLoggedIn();
            var books = DC.Books.OrderBy(b => b.Title).ToList();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Books:");
            if (!books.Any())
            {
                Console.WriteLine("No books available.");
                Console.ResetColor();
                return;
            }

            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
            Console.ResetColor();
        }

        public void SearchBooks()
        {
            CheckLoggedIn();
            Console.WriteLine("Enter search term:");
            string search = (Console.ReadLine() ?? string.Empty).ToLower();
            var results = DC.Books
                .Where(b =>
                    b.Title.ToLower().Contains(search) ||
                    b.Author.ToLower().Contains(search) ||
                    b.Genre.ToLower().Contains(search) ||
                    b.ISBN.ToLower().Contains(search))
                .OrderBy(b => b.Title)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!results.Any())
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (var b in results) Console.WriteLine(b);
            }
            Console.ResetColor();
        }

        public void CheckAdmin()
        {
            if (UserService.loggedInUser == null) throw new Exception("You must be logged in to perform this action.");
            var role = UserService.loggedInUser.Role;
            if (role != UserRoles.Admin && role != UserRoles.Librarian) throw new Exception("You must be an admin or librarian to perform this action.");
        }

        public void CheckLoggedIn()
        {
            if (UserService.loggedInUser == null) throw new Exception("You must be logged in to perform this action.");
        }
    }
}
