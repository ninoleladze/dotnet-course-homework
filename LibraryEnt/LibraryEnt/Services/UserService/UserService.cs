using LibraryEnt.Data;
using LibraryEnt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEnt.Services.UserService
{
        internal class UserService
        {
            private DataContext DC = new DataContext();
            public static User? loggedInUser { get; private set; }

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

                var user = new User
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
                string password = Console.ReadLine();

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
        }

    }

