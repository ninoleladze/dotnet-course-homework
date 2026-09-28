using LibraryApp1.Data;
using LibraryApp1.Enums;
using LibraryApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibraryApp1.Services.User
{
    internal class UserService : IUserService
    {
        private DataContext DC = new DataContext();
        public static Models.User? loggedInUser { get; private set; }

        public void Register()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Register a new user:");

            string fullname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullname)) throw new Exception("Username cannot be empty.");

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email cannot be empty.");
            if (!email.Contains("@") || !email.Contains(".")) throw new Exception("Email is not valid.");
            if (DC.Users.Any(u => u.Email == email)) throw new Exception("Email is already registered.");

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password cannot be empty.");
            if (password.Length < 6) throw new Exception("Password must be at least 6 characters long.");


            Console.ResetColor();

            var user = new Models.User
            {
                FullName = fullname,
                Email = email,  
                Password = password
            };

            DC.Users.Add(user);
            DC.SaveChanges();
            
          

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Registration successful!");
            Console.ResetColor();
        }

        public void Login()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (loggedInUser != null) throw new Exception("A user is already logged in.");

            Console.WriteLine("Login:");
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine() ;

            var user = DC.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null) throw new Exception("Invalid email or password.");
            loggedInUser = user;
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Login successful! Welcome, {loggedInUser.FullName}.");
            Console.ResetColor();
        }

        public void logout()
        {
            if (loggedInUser == null) throw new Exception("No user is currently logged in.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Logout successful! Goodbye, {loggedInUser.FullName}.");
            Console.ResetColor();
            loggedInUser = null;
        }

        public void ShowProfile()
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to view your profile.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("User Profile:");
            Console.WriteLine($"Name : {loggedInUser.FullName}");
            Console.WriteLine($"Email: {loggedInUser.Email}");
            Console.WriteLine($"Role : {loggedInUser.Role}");
            Console.WriteLine();

            var borrows = DC.Borrows
                .Include(b => b.Book)
                .Where(b => b.UserId == loggedInUser.Id)
                .OrderByDescending(b => b.BorrowedAt)
                .ToList();

            var active = borrows.Where(b => b.Status == BorrowStatus.Active).ToList();
            var overdue = borrows.Where(b => b.Status == BorrowStatus.Overdue).ToList();
            var returned = borrows.Where(b => b.Status == BorrowStatus.Returned).ToList();
            var lost = borrows.Where(b => b.Status == BorrowStatus.Lost).ToList();

            Console.WriteLine($"Active borrows : {active.Count}");
            Console.WriteLine($"Overdue         : {overdue.Count}");
            Console.WriteLine($"Returned        : {returned.Count}");
            Console.WriteLine($"Lost            : {lost.Count}");
            Console.WriteLine();

            if (!borrows.Any())
            {
                Console.WriteLine("You have no borrow records.");
                Console.ResetColor();
                return;
            }

            var currentGrouped = borrows
                .Where(b => b.Status == BorrowStatus.Active || b.Status == BorrowStatus.Overdue)
                .GroupBy(b => b.Book)
                .ToList();

            if (currentGrouped.Any())
            {
                Console.WriteLine("Currently borrowed (grouped by book):");
                foreach (var g in currentGrouped)
                {
                    var book = g.Key;
                    var count = g.Count();
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN}) - Copies borrowed: {count}");
                    foreach (var item in g)
                    {
                        Console.WriteLine($"    Borrowed at: {item.BorrowedAt:u}  Status: {item.Status}");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Recent borrow history:");
            foreach (var b in borrows.Take(10))
            {
                var book = b.Book;
                Console.WriteLine($"- [{b.Status}] {book.Title} by {book.Author} (ISBN: {book.ISBN}) BorrowedAt: {b.BorrowedAt:u} ReturnedAt: {(b.ReturnedAt?.ToString("u") ?? "Not Returned")}");
            }

            Console.ResetColor();
        }
    }
}
