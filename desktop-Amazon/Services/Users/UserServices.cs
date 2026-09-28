using Amazon.Data;
using Amazon.Models;
using System;
using System.Linq;

namespace Amazon.Services.Users
{
    internal class UserServices : IUserServices
    {
        private readonly DataContext _db = new DataContext();

        public static User? LoggedInUser { get; set; }
        public static bool IsLoggedIn() => LoggedInUser != null;

        public void Register()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Username is required!");

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email is required!");
            if (!email.Contains("@")) throw new Exception("Invalid email format!");

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is required!");
            if (password.Length < 6) throw new Exception("Password must be at least 6 characters!");

           
            if (_db.Users.Any(u => u.Fullname == username))
                throw new Exception("Username already exists!");
            if (_db.Users.Any(u => u.Email == email))
                throw new Exception("Email already registered!");

            var user = new User
            {
                Fullname = username.Trim(),
                Email = email.Trim(),
                Password = password 
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            Console.WriteLine("User registered successfully!");
        }

        public void Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Username is required!");

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is required!");

            var user = _db.Users.FirstOrDefault(u => u.Fullname == username && u.Password == password);
            if (user == null) throw new Exception("Invalid username or password!");

            LoggedInUser = user;
            Console.WriteLine($"Welcome, {user.Fullname}!");
        }

        public void Logout()
        {
            if (!IsLoggedIn()) throw new Exception("No user is currently logged in!");

            Console.WriteLine($"User {LoggedInUser.Fullname} logged out.");
            LoggedInUser = null;
        }

        public void ShowProfile()
        {
            if (!IsLoggedIn()) throw new Exception("You must be logged in to view profile!");

            Console.WriteLine("User Profile:");
            Console.WriteLine($"Id: {LoggedInUser.Id}");
            Console.WriteLine($"Username: {LoggedInUser.Fullname}");
            Console.WriteLine($"Email: {LoggedInUser.Email}");
        }
    }
}