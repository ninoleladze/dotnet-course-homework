using ShoppingApp.Data;
using ShoppingApp.Models;
using System;
using System.Linq;

namespace ShoppingApp.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _db;
        public static User? LoggedInUser { get; private set; }

        public UserServices()
        {
            _db = new DataContext();
        }

        public UserServices(DataContext db)
        {
            _db = db;
        }

        public void Register()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Register(username, email, password);
        }

        public void Register(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Username required!");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new Exception("Valid email required!");
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6) throw new Exception("Password must be at least 6 characters!");

            if (_db.Users.Any(u => u.Username == username)) throw new Exception("Username already exists!");
            if (_db.Users.Any(u => u.Email == email)) throw new Exception("Email already registered!");

            var user = new User { Username = username.Trim(), Email = email.Trim(), Password = password };
            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("User registered successfully!");
        }

        public void Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Login(username, password);
        }

        public User? Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password)
                       ?? throw new Exception("Invalid credentials!");

            LoggedInUser = user;
            Console.WriteLine($"Welcome, {user.Username}!");
            return user;
        }

        public void Logout()
        {
            if (LoggedInUser == null) throw new Exception("No user logged in!");
            Console.WriteLine($"User {LoggedInUser.Username} logged out.");
            LoggedInUser = null;
        }

        public void ShowProfile()
        {
            if (LoggedInUser == null) throw new Exception("Login required!");
            Console.WriteLine($"Id: {LoggedInUser.Id}, Username: {LoggedInUser.Username}, Email: {LoggedInUser.Email}");
        }
    }
}