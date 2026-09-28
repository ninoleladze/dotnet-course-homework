using LibraryApp1.Data;
using LibraryApp1.Enums;
using LibraryApp1.Models;
using LibraryApp1.Services.User;
using System;
using System.Linq;

namespace LibraryApp1.Services.Borrow
{
    internal class BorrowService
    {
        private DataContext DC = new DataContext();

        public void BorrowBook()
        {
            CheckLoggedIn();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter Book ID to borrow:");
            if (!int.TryParse(Console.ReadLine(), out int bookId)) throw new Exception("Invalid book Id.");

            var book = DC.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null) throw new Exception("Book not found.");
            if (book.Copies <= 0) throw new Exception("Book is not available for borrowing.");

            var user = UserService.loggedInUser!;

            var borrow = new Models.Borrow
            {
                UserId = user.Id,
                Name = user.FullName,
                BookId = book.Id,
                BorrowedAt = DateTime.UtcNow,
                Status = BorrowStatus.Active
            };

            book.Copies -= 1;
            book.Status = book.Copies > 0 ? BookStatus.Available : BookStatus.Borrowed;

            DC.Borrows.Add(borrow);
            DC.Books.Update(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book borrowed successfully.");
            Console.ResetColor();
        }

        public void ReturnBook()
        {
            CheckLoggedIn();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter Book ID to return:");
            if (!int.TryParse(Console.ReadLine(), out int bookId)) throw new Exception("Invalid book Id.");

            var user = UserService.loggedInUser!;
            var borrow = DC.Borrows
                .Where(b => b.BookId == bookId && b.UserId == user.Id && b.Status == BorrowStatus.Active)
                .FirstOrDefault();

            if (borrow == null) throw new Exception("Active borrow record not found for this book and user.");

            borrow.ReturnedAt = DateTime.UtcNow;
            borrow.Status = BorrowStatus.Returned;

            var book = DC.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.Copies += 1;
                book.Status = BookStatus.Available;
            }

            DC.Borrows.Update(borrow);
            if (book != null) DC.Books.Update(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book returned successfully.");
            Console.ResetColor();
        }

        public void ListBorrowedBooks()
        {
            CheckLoggedIn();

            var user = UserService.loggedInUser!;
            bool isStaff = user.Role == UserRole.Librarian || user.Role == UserRole.Admin;

            var borrows = DC.Borrows
                .Where(b => b.Status == BorrowStatus.Active)
                .OrderBy(b => b.BorrowedAt)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Borrowed books:");
            if (!borrows.Any())
            {
                Console.WriteLine("No borrowed books found.");
                Console.ResetColor();
                return;
            }

            foreach (var br in borrows)
            {
                if (!isStaff && br.UserId != user.Id) continue;
                Console.WriteLine(br);
            }
            Console.ResetColor();
        }

        public void ListOverdueBooks()
        {
            CheckLoggedIn();
            var threshold = DateTime.UtcNow.AddDays(-14);

            var overdue = DC.Borrows
                .Where(b => b.Status == BorrowStatus.Active && b.BorrowedAt <= threshold)
                .OrderBy(b => b.BorrowedAt)
                .ToList();

            if (overdue.Any())
            {
                foreach (var b in overdue) b.Status = BorrowStatus.Overdue;
                DC.SaveChanges();
            }

            var user = UserService.loggedInUser!;
            bool isStaff = user.Role == UserRole.Librarian || user.Role == UserRole.Admin;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Overdue borrows:");
            var list = DC.Borrows.Where(b => b.Status == BorrowStatus.Overdue).OrderBy(b => b.BorrowedAt).ToList();
            if (!list.Any())
            {
                Console.WriteLine("No overdue borrows found.");
                Console.ResetColor();
                return;
            }

            foreach (var br in list)
            {
                if (!isStaff && br.UserId != user.Id) continue;
                Console.WriteLine(br);
            }
            Console.ResetColor();
        }

        public void ReturnOverdueBook()
        {
            CheckAdmin();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter Borrow ID to return (overdue):");
            if (!int.TryParse(Console.ReadLine(), out int borrowId)) throw new Exception("Invalid borrow Id.");

            var borrow = DC.Borrows.FirstOrDefault(b => b.Id == borrowId && b.Status == BorrowStatus.Overdue);
            if (borrow == null) throw new Exception("Overdue borrow record not found.");

            borrow.ReturnedAt = DateTime.UtcNow;
            borrow.Status = BorrowStatus.Returned;

            var book = DC.Books.FirstOrDefault(b => b.Id == borrow.BookId);
            if (book != null)
            {
                book.Copies += 1;
                book.Status = BookStatus.Available;
            }

            DC.Borrows.Update(borrow);
            if (book != null) DC.Books.Update(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Overdue book returned successfully.");
            Console.ResetColor();
        }

        public void LostBook()
        {
            CheckAdmin();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter Borrow ID to mark as lost:");
            if (!int.TryParse(Console.ReadLine(), out int borrowId)) throw new Exception("Invalid borrow Id.");

            var borrow = DC.Borrows.FirstOrDefault(b => b.Id == borrowId && b.Status != BorrowStatus.Lost && b.Status != BorrowStatus.Returned);
            if (borrow == null) throw new Exception("Borrow record not found or already closed.");

            borrow.Status = BorrowStatus.Lost;
            borrow.ReturnedAt = DateTime.UtcNow;

            var book = DC.Books.FirstOrDefault(b => b.Id == borrow.BookId);
            if (book != null)
            {
              
                book.Status = book.Copies > 0 ? BookStatus.Available : BookStatus.Lost;
            }

            DC.Borrows.Update(borrow);
            if (book != null) DC.Books.Update(book);
            DC.SaveChanges();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book marked as lost.");
            Console.ResetColor();
        }
        public void CheckAdmin()
        {
            if (UserService.loggedInUser == null) throw new Exception("You must be logged in to perform this action.");
            var role = UserService.loggedInUser.Role;
            if (role != UserRole.Admin && role != UserRole.Librarian) throw new Exception("You must be an admin or librarian to perform this action.");
        }

        public void CheckLoggedIn()
        {
            if (UserService.loggedInUser == null) throw new Exception("You must be logged in to perform this action.");
        }
    }
}
