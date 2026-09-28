namespace Library2
{
    internal class LibraryService
    {
        private List<Book> books= new List<Book>()
        {
            new Book(){Author="Author - 1", Title = "Title - 1", Year = 1990},
            new Book(){Author="Author - 2", Title = "Title - 2", Year = 1994},
            new Book(){Author="Author - 3", Title = "Title - 3", Year = 1996},
            new Book(){Author="Author - 4", Title = "Title - 4", Year = 1999},
            new Book(){Author="Author - 5", Title = "Title - 5", Year = 1991},
            new Book(){Author="Author - 6", Title = "Title - 6", Year = 1997},
            new Book(){Author="Author - 7", Title = "Title - 7", Year = 1995},

        };

        public  void AddBook(string title, string author, int year)
        {
            if (title.Length < 2 || title.Length > 50) 
            { throw new Exception("Min Title Length is 2 and max is 50"); }
            if (author.Length < 2 || author.Length > 50) 
            { throw new Exception("Min Title Length is 2 and max is 50"); }
            if (year < 1000 || year > 2025)
            { throw new Exception("min year length is 1000 and max is 2025 "); }

            Book book = new Book()
            {
                Author = author,
                Title = title,
                Year = year

            };

            books.Add(book);
            Console.WriteLine("book added successfully");
        }

        public void BorrowBook(int bookId) {

            Book? foundedbook= null;

            foreach (var item in books)
            {
                if (item.Id == bookId)
                {
                    foundedbook = item;
                }
            }

            if (foundedbook == null)
            {
                throw new Exception("book not found");
            }


            if (foundedbook.IsBorrowed)
            {
                throw new Exception("is already borrowed");
            }
            else
            {
                foundedbook.IsBorrowed = true;
                Console.WriteLine("book successfully borrowed ");

            }
            
        }


        public void ReturnBook(int bookId)
        {

            Book? foundedbook = null;

            foreach (var item in books)
            {
                if (item.Id == bookId && item.IsBorrowed)
                {
                    foundedbook = item;
                }
            }
            if (foundedbook == null)
            {
                throw new Exception("NOT FOUND");
            }

            foundedbook.IsBorrowed = false;
            Console.WriteLine("success");





        }


        public void ListAvailableBooks()
        {
            foreach (var book in books)
            {
                if (!book.IsBorrowed)
                {
                    Console.WriteLine(book);

                }
            }
        }
        public void GetUserBorrowedBooks() {

            foreach (var book in books)
            {
                if (book.IsBorrowed)
                {
                    Console.WriteLine(book);

                }
            }
        }
























    }
}
