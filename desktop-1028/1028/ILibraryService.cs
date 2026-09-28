using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1028
{
    internal interface ILibraryService
    {

        void showBorrowedBooks();
        void showAvailableBooks();
        void borrowBook();
        void returnBook();
        void addBook();
        void removeBook();
        void updateBook();
        void SearchBookByTitle();
        void searchBookByAuthor();

        void filterBooksByYear();

        void GetBookById();


    }
}
