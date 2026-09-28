using _1._16.Data;
using _1._16.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._16.Services
{
    internal class UserService

    {

        private DataContext DC = new DataContext();

        public void Register()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter number:");
            string number = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            User userObj = new User()
            {
                Username = username,
                Email = email,
                Password = password,
                Details = new UserDetails()
                {
                    PhoneNumber = number,
                }

            };
            DC.users.Add(userObj);
            DC.SaveChanges();
            Console.WriteLine("success");


        }
        public void GetUsers()
        {
        var users = DC.users
                .Include(u => u.Details)
                .ToList();
            foreach (var user in users) {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"email: {user.Email}");
                Console.WriteLine($"phone :{user.Details.PhoneNumber}");
            }


        }
        public void GetUserById()
        {

            Console.WriteLine("enter user id:");
            int userId = int.Parse( Console.ReadLine() );
            var user = DC.users.Include(u => u.Details)
                .FirstOrDefault(e=>e.Id == userId );
            if (user == null) 
            { Console.WriteLine("user not found:"); }
            else
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"email: {user.Email}");
                Console.WriteLine($"phone :{user.Details.PhoneNumber}");
            }

        }

    }
}
