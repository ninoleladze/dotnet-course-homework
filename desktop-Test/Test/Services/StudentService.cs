using Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Test.Services
{
    internal class StudentService
    {
        private List<student> studentsList = new List<student>();
        private string path = "students.json";

        public void LoadStudents()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<student>>(json);
                if (data != null) studentsList = data;
            }
        }

        public void CreateStudent()
        {
            Console.WriteLine("enter first name: ");
            string firstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstName)) throw new Exception("first name is required");

            Console.WriteLine("enter last name: ");
            string lastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(lastName)) throw new Exception("last name is required");

            Console.WriteLine("enter age: ");
            int age = int.Parse(Console.ReadLine());
            if (age < 1) throw new Exception("age must be positive");

            Console.WriteLine("enter email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("email is required");

            var exists = studentsList.Any(s => s.Email == email);
            if (exists) throw new Exception("student already exists");

            student s = new student()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email
            };

            studentsList.Add(s);
            SaveData();
            Console.WriteLine("student created successfully");
        }

        public void EditStudent()
        {
            ShowStudents();
            Console.WriteLine("enter student id:");
            int id = int.Parse(Console.ReadLine());

            var s = studentsList.FirstOrDefault(x => x.Id == id);
            if (s == null) throw new Exception("student not found");

            Console.WriteLine($"selected student: {s}");

            Console.WriteLine("enter new first name (leave empty to skip): ");
            string fn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fn)) s.FirstName = fn;

            Console.WriteLine("enter new last name (leave empty to skip): ");
            string ln = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ln)) s.LastName = ln;

            Console.WriteLine("enter new age (leave empty to skip): ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                int age = int.Parse(ageInput);
                if (age < 1) throw new Exception("age must be positive");
                s.Age = age;
            }

            Console.WriteLine("enter new email (leave empty to skip): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) s.Email = email;

            SaveData();
            Console.WriteLine("student updated successfully");
        }

        public void DeleteStudent()
        {
            ShowStudents();
            Console.WriteLine("enter student id:");
            int id = int.Parse(Console.ReadLine());

            var s = studentsList.FirstOrDefault(x => x.Id == id);
            if (s == null) throw new Exception("student not found");

            studentsList.Remove(s);
            SaveData();
            Console.WriteLine("student deleted successfully");
        }

        public void ShowStudents()
        {
            if (!studentsList.Any()) throw new Exception("no students found");
            foreach (var s in studentsList) Console.WriteLine(s);
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(studentsList);
            File.WriteAllText(path, json);
        }
    }
}