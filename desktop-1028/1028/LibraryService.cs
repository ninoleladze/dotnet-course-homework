using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1028
{
    internal class LibraryService : ILibraryService

    {

        private List<Book> books = new List<Book>()
        {
            new Book(){Author="Author - 1", Title = "Title - 1", Year = 1990},
            new Book(){Author="Author - 2", Title = "Title - 2", Year = 1994},
            new Book(){Author="Author - 3", Title = "Title - 3", Year = 1996},
            new Book(){Author="Author - 4", Title = "Title - 4", Year = 1999},
            
        };

        public void addBook()
        {
            
            Console.WriteLine("enter book title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("title cannot be empty");
            }
            Console.WriteLine("enter book author: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author)) {
                throw new Exception("author cannot be empty");
            }
            Console.WriteLine("enter book year: ");
            int year = int.Parse(Console.ReadLine());
            if (year < 1000 || year > 2025)
            {
                throw new Exception("year is not correct");
            }


            Book newBook = new Book()
            {
                Title = title,
                Author = author,
                Year = year
            };
            books.Add(newBook);
            Console.WriteLine("Book added successfully(in list).");
        }

        public void borrowBook()
        {
            showAvailableBooks();
            Console.WriteLine("");
            Console.WriteLine("enter book id to borrow: ");
            int id = int.Parse(Console.ReadLine());
            var foundedbook = books.FirstOrDefault(b => b.Id == id);

            if (foundedbook== null) throw new Exception("book not found");
            
            if (foundedbook.IsBorrowed)throw new Exception("book is already borrowed");

            foundedbook.IsBorrowed = true;
            Console.WriteLine("book borrowed successfully.");


        }


        
        

        public void returnBook()
        {
            showBorrowedBooks();
            Console.WriteLine("");

            Console.WriteLine("enter book id");


            int id = int.Parse(Console.ReadLine());
            var foundedbook = books.FirstOrDefault(b => b.Id == id);

            if (foundedbook == null) throw new Exception("book not found");

            if (!foundedbook.IsBorrowed) throw new Exception("book is not borrowed");

            foundedbook.IsBorrowed = false;
            Console.WriteLine("book return successfully.");
        }

        public void showAvailableBooks()
        {
      
            var availableBooks = books.Where(b => !b.IsBorrowed).ToList();

            foreach (var book in availableBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void showBorrowedBooks()
        {
           
            var borrowedBooks = books.Where(b => b.IsBorrowed).ToList();
          
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine(book.ToString());
            }

        }

        public void updateBook()
        {
            showAvailableBooks();
            Console.WriteLine("");
            Console.WriteLine("enter book id to update: ");
            int id = int.Parse(Console.ReadLine());
            var foundedbook = books.FirstOrDefault(b => b.Id == id);
            if (foundedbook == null) throw new Exception("book not found");
            if(foundedbook.IsBorrowed) throw new Exception("cannot update borrowed book");

            Console.WriteLine("enter new title: ");
            string title = Console.ReadLine();
            Console.WriteLine("enter new author: ");
            string author = Console.ReadLine();
            Console.WriteLine("enter new year: ");
            int year = int.Parse(Console.ReadLine());
            foundedbook.Title = title;
            foundedbook.Author = author;
            foundedbook.Year = year;
            Console.WriteLine("book updated successfully.");


        }
        

        public void removeBook()
        {
            Console.WriteLine("enter book id:");
            int id = int.Parse(Console.ReadLine());
            var foundedbook = books.FirstOrDefault(b => b.Id == id);
            if (foundedbook == null) throw new Exception("book not found");
            books.Remove(foundedbook);
            Console.WriteLine("Book removed successfully(from list).");




        }
        public void SearchBookByTitle()
        {

            Console.WriteLine("search book by title");
            string title = Console.ReadLine();
            var filteredbooks = books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();

            if (!filteredbooks.Any()) throw new Exception($"BOOK NOT FOUND : {title}");
            foreach (var book in filteredbooks)
            {
                Console.WriteLine(book);
            }
        }

        public void searchBookByAuthor()
        {
            Console.WriteLine("search book by author");
           
            string author = Console.ReadLine();
            var filteredbooks = books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
            if (!filteredbooks.Any()) throw new Exception($"BOOK NOT FOUND : {author}");
            foreach (var book in filteredbooks)
            {
                Console.WriteLine(book);
            }



        }

        public void filterBooksByYear()
        {
            Console.WriteLine("filter books by year");
            int year = int.Parse(Console.ReadLine());
            var filteredbooks = books.Where(b => b.Year == year).ToList();
            if (!filteredbooks.Any()) throw new Exception($"BOOK NOT FOUND : {year}");
            foreach (var book in filteredbooks)
            {
                Console.WriteLine(book);
            }
        }

        public void GetBookById()
        {

            Console.WriteLine("filter books by id");
            int id = int.Parse(Console.ReadLine());
            var foundedbook = books.FirstOrDefault(b => b.Id == id);
            if (foundedbook == null) throw new Exception("book not found");
            Console.WriteLine(foundedbook.ToString());



        }

        

    }
}
