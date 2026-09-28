using Ebay.Data;
using Ebay.Enums;
using Ebay.Models;
namespace Ebay.Services.Users
{
    internal class UserServices : IUserServices

    {
        private readonly DataContext dataContext = new DataContext();
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

            if (dataContext.users.Any(u => u.Fullname == username))
                throw new Exception("Username already exists!");
            if (dataContext.users.Any(u => u.Email == email))
                throw new Exception("Email already registered!");

            var user = new User
            {
                Fullname = username.Trim(),
                Email = email.Trim(),
                Password = password
            };

            if (!dataContext.users.Any())
            {
                user.Role = UserRoles.Admin;
            }

            dataContext.users.Add(user);
            dataContext.SaveChanges();

            Console.WriteLine("User registered successfully!");
            if (user.IsAdmin()) Console.WriteLine("This account has been granted Admin role.");
        }
        public void Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("Username is required!");

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is required!");

            var user = dataContext.users.FirstOrDefault(u => u.Fullname == username && u.Password == password);
            if (user == null) throw new Exception("Invalid username or password!");

            LoggedInUser = user;
            Console.WriteLine($"Welcome, {user.Fullname}!");
            if (user.IsAdmin()) Console.WriteLine("You are logged in as Admin.");
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
            Console.WriteLine($"Role: {LoggedInUser.Role}");
        }


        public void PromoteToAdmin()
        {
            if (!IsLoggedIn()) throw new Exception("You must be logged in to perform this action.");
            if (!LoggedInUser.IsAdmin()) throw new Exception("Only Admins can promote other users.");

            Console.WriteLine("Enter email or username of user to promote:");
            string? identifier = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(identifier)) throw new Exception("Email or username is required!");

            var user = dataContext.users.FirstOrDefault(u =>
                string.Equals(u.Email, identifier.Trim(), StringComparison.OrdinalIgnoreCase)
                || string.Equals(u.Fullname, identifier.Trim(), StringComparison.OrdinalIgnoreCase));

            if (user == null) throw new Exception("User not found!");

            if (user.IsAdmin())
            {
                Console.WriteLine("User is already an Admin.");
                return;
            }

            user.Role = UserRoles.Admin;
            dataContext.SaveChanges();

            Console.WriteLine($"User {user.Fullname} has been promoted to Admin.");
        }
    }
}