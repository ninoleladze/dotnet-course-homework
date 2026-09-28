using Inatagram.Models;

namespace Inatagram.Services
{
    internal class UsersService
    {
        private Baza baza = new Baza();
        public static User? LoggedInUser { get; set; }

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("username is required.");

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("email is required.");

            if (baza.Users.Any(u => u.Email == email))
                throw new Exception("email already exists.");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("password is required.");

            User userObj = new User()
            {
                Email = email,
                Password = password,
                Username = username
            };

            baza.Users.Add(userObj);
            baza.SaveChanges();

            Console.WriteLine("registered successfully.");
        }
        public void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("email is required.");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("password is required.");

            var user = baza.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
                throw new Exception("email or password is not correct.");

            Console.WriteLine("logged in successfully");
            Console.WriteLine($"logged in user: {user}");
            LoggedInUser = user;
        }
        public void Logout()
        {
            LoggedInUser = null;
            Console.WriteLine("logged out.");
        }

        public void EditProfile()
        {
            if (LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Enter new username (leave empty to keep current): ");
            string newUsername = Console.ReadLine();

            Console.Write("Enter new email (leave empty to keep current): ");
            string newEmail = Console.ReadLine();

            Console.Write("Enter new password (leave empty to keep current): ");
            string newPassword = Console.ReadLine();

            var user = baza.Users.FirstOrDefault(u => u.Id == LoggedInUser.Id);
            if (user == null)
                throw new Exception("User not found.");

            if (!string.IsNullOrWhiteSpace(newEmail) && newEmail != user.Email)
            {
                if (baza.Users.Any(u => u.Email == newEmail))
                    throw new Exception("email already exists.");

                user.Email = newEmail;
            }

            if (!string.IsNullOrWhiteSpace(newUsername))
                user.Username = newUsername;

            if (!string.IsNullOrWhiteSpace(newPassword))
                user.Password = newPassword;

            baza.SaveChanges();

           
            LoggedInUser = user;

            Console.WriteLine("profile updated successfully.");
        }
        public void DeleteProfile()
        {
            if (LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Are you sure you want to delete your profile? type 'yes' to confirm: ");
            string confirm = Console.ReadLine();

            if (confirm != "yes")
            {
                Console.WriteLine("delete cancelled.");
                return;
            }

            var user = baza.Users.FirstOrDefault(u => u.Id == LoggedInUser.Id);
            if (user == null)
                throw new Exception("User not found.");

            baza.Users.Remove(user);
            baza.SaveChanges();

            LoggedInUser = null;
            Console.WriteLine("profile deleted.");
        }

        public void ViewProfile()
        {
            if (LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.WriteLine(LoggedInUser);
        }
    }
}
