using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Services.Book
{
    internal interface IBookService
    {
        public void CreateBook();
        public void DeleteBook();
        public void UpdateBook();
        public void GetAllBooks();
        public void SearchBooks();
        public void CheckLoggedIn();
        public void CheckAdmin();

    }
}
