using _1111.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _1111.Services
{
    internal class UsersService
    {
        private List<User> usersList = new List<User>();
        private String path = "users.json";





        public static User? currentUser = null;

        public void LoadUsers() {

            if (File.Exists(path)){
                
                string json = File.ReadAllText(path);

                var data = JsonSerializer.Deserialize<List<User>>(json);
                if(data != null)usersList = data;


            }}

        public void Register() {
            Console.WriteLine("enter name:");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username))throw new Exception ("name is requiered") ;
            Console.WriteLine("enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email)) throw new Exception("email is requiered");
            var userExists = usersList.Any(x => x.Email == email);
            if (userExists) throw new Exception("user already exists");


            Console.WriteLine("enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("password is requered");

            User user = new User()
            {
                Name = username,
                Email = email,
                Password = password

            };
            usersList.Add(user);

            SaveData();

            Console.WriteLine("registered successfully");


        }

        public void Login() {

            Console.WriteLine("enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email)) throw new Exception("email is requiered");
       

            Console.WriteLine("enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("password is requered");

            var user= usersList.FirstOrDefault(x => x.Email == email&& x.Password== password);

            if (user == null) throw new Exception("USER NOT FOUND");

            Console.WriteLine("user logged in succesfully");
            Console.WriteLine("logged in user data");
            Console.WriteLine(user);


            currentUser = user;






        }

        public void logout()
        {
            currentUser = null;
        }


        private void SaveData() {
        
           string json = JsonSerializer.Serialize(usersList);
            File.WriteAllText(path, json);


        

        }


    }
}
