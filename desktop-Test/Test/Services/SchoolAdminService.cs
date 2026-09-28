using Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Test.Services
{
    internal class SchoolAdminService
    {
        private List<SchoolAdmin> adminsList = new List<SchoolAdmin>();
        private string path = "admins.json";

        public static SchoolAdmin? currentAdmin = null;

        public void LoadAdmins()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<SchoolAdmin>>(json);
                if (data != null) adminsList = data;
            }
        }

        public void RegisterAdmin()
        {
            Console.WriteLine("enter username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("username is required");

            Console.WriteLine("enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("password is required");

            var exists = adminsList.Any(a => a.Username == username);
            if (exists) throw new Exception("admin already exists");

            SchoolAdmin admin = new SchoolAdmin()
            {
                Username = username,
                Password = password
            };

            adminsList.Add(admin);
            SaveData();
            Console.WriteLine("admin registered successfully");
        }

        public void Login()
        {
            Console.WriteLine("enter username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) throw new Exception("username is required");

            Console.WriteLine("enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("password is required");

            var admin = adminsList.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (admin == null) throw new Exception("admin not found");

            currentAdmin = admin;
            Console.WriteLine("admin logged in successfully");
            Console.WriteLine(admin);
        }

        public void Logout()
        {
            currentAdmin = null;
            Console.WriteLine("logged out successfully");
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(adminsList);
            File.WriteAllText(path, json);
        }
    }
}