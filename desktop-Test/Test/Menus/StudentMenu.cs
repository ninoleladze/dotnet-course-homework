using Test.Services;
using System;

namespace Test.Menus
{
    internal class StudentMenu
    {
        private static StudentService _studentService = new StudentService();

        public static void Start(StudentService service = null)
        {
            if (service != null) _studentService = service;
            _studentService.LoadStudents();

            while (true)
            {
                try
                {
                    Console.WriteLine("=== Student Menu ===");
                    Console.WriteLine("1. Create Student");
                    Console.WriteLine("2. Edit Student");
                    Console.WriteLine("3. Delete Student");
                    Console.WriteLine("4. Show Students");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter choice: ");
                    string key = Console.ReadLine();

                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            _studentService.CreateStudent();
                            break;
                        case "2":
                            Console.Clear();
                            _studentService.EditStudent();
                            break;
                        case "3":
                            Console.Clear();
                            _studentService.DeleteStudent();
                            break;
                        case "4":
                            Console.Clear();
                            _studentService.ShowStudents();
                            break;
                        case "5":
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}