using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _1107
{
    internal class UserService
    {
        private List<User> userList = new List<User>();
        private string path = "users.json";
        private User? LoggedInUser = null;

        public void loadUsers()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                var data = JsonSerializer.Deserialize<List<User>>(json);

                if (data != null) userList = data;
            }
        }
        public void register()
        {
            Console.WriteLine("enter name: ");
            string name = Console.ReadLine();


            Console.WriteLine("enter email:");
            string email = Console.ReadLine();

          
            if (!string.IsNullOrWhiteSpace(email) && userList.Any(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("email already exists");
                return;
            }

            Console.WriteLine("enter password");
            string password = Console.ReadLine();

            User user = new User()
            {
                Name = name,
                Password = password,
                Email = email
            };

            userList.Add(user);
            saveData();

            Console.WriteLine("registered successfully.");
        }
        public void login()
        {

            Console.WriteLine("enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("enter password:");
            string password = Console.ReadLine();

            var user = userList.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (user == null)
            {

                Console.WriteLine("user not found");
            }
            else
            {
                LoggedInUser = user;
                Console.WriteLine("user logged in successfully");

            }

        }
        public void showUsers()
        {

            foreach (var item in userList)
            {
                item.showinfo();
            }

        }
        public void logout()
        {

            if (LoggedInUser == null)
            {
                Console.WriteLine("user is not logged in");
            }
            else
            {

                LoggedInUser = null;
            }

        }

        public void EditUser()
        {
            if (LoggedInUser == null)
            {
                Console.WriteLine("user is not logged in");
                return;
            }

            Console.WriteLine("enter new name:");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("invalid name. update canceled.");
                return;
            }

            LoggedInUser.Name = newName;
            saveData();
            Console.WriteLine("username updated successfully.");
        }

        public void UpdatePassword()
        {
            Console.WriteLine("enter email:");
            string? email = Console.ReadLine();

            Console.WriteLine("enter old password:");
            string? oldPassword = Console.ReadLine();

            Console.WriteLine("enter new password:");
            string? newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("email required.");
                return;
            }

            var user = userList.FirstOrDefault(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                Console.WriteLine("user not found.");
                return;
            }

           
            if (LoggedInUser == null || !string.Equals(LoggedInUser.Email, user.Email, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("you must be logged in as this user to change the password.");
                return;
            }

            if (!string.Equals(user.Password, oldPassword))
            {
                Console.WriteLine("old password is incorrect.");
                return;
            }

            user.Password = newPassword;
            saveData();
            Console.WriteLine("password updated successfully.");
        }

        public void showLoggedInUser()
        {
            if (LoggedInUser == null)
            {
                Console.WriteLine("user is not logged in");
            }
            else
            {
                LoggedInUser.showinfo();
            }
        }

        private void saveData()
        {
            string json = JsonSerializer.Serialize(userList);
            File.WriteAllText(path, json);
        }

    }
}