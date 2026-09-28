using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Services.Borrow
{
    internal interface IBorrowService
    {
        public void BorrowBook();
        public void ReturnBook();
        public void ReturnBook(int bookId);
        public void ReturnBook(string bookName);
        public void ListBorrowedBooks();
        public void ListOverdueBooks();
        public void LostBook();

    }
}
