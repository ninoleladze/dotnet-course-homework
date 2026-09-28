using _12._19_student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._19_student.Services
{
    internal class StudentService
    {
        private Baza Baza = new Baza();

        public void CreateStudent()
        {
            Console.WriteLine("Enter Student username: ");
            string username = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(username))throw new Exception("Username is required");
            Console.WriteLine("Enter Student email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email is required");
            Console.WriteLine("Enter Student phone: ");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone)) throw new Exception("Phone is required");

            var student = new Student()
            {
                Username = username,
                Email = email,
                Phone = phone
            };

            Baza.Student.Add(student);
            Baza.SaveChanges();
            Console.WriteLine("success!");



        }

        public void DeleteStudent()    
        {
            Console.WriteLine("Enter book Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            var student = Baza.Student.Find(id);
            if (student == null)throw new Exception("Student not found");
            Baza.Student.Remove(student);
            Baza.SaveChanges();
            Console.WriteLine("Student deleted successfully");



        }
        public void EditStudent()
        {
            Console.WriteLine("Enter student Id to edit: ");
            int id = int.Parse(Console.ReadLine());
            var student = Baza.Student.Find(id);
            if (student == null) throw new Exception("Student not found");
            Console.WriteLine("Enter new username (leave blank to keep current): ");
            string username = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(username))
            {
                student.Username = username;
            }
            Console.WriteLine("Enter new email (leave blank to keep current): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
            {
                student.Email = email;
            }
            Console.WriteLine("Enter new phone (leave blank to keep current): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                student.Phone = phone;
            }
            Baza.SaveChanges();
            Console.WriteLine("Student updated successfully");

        }
        public void ShowStudents()
        {
            var students = Baza.Student.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
