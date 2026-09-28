using Test.Services;
using System;

namespace Test.Menus
{
    internal class SchoolAdminMenu
    {
        private static SchoolAdminService _adminService = new SchoolAdminService();
        private static StudentService _studentService = new StudentService();
        private static CourseService _courseService = new CourseService();
        private static EnrollmentService _enrollmentService = new EnrollmentService();

        public static void Start()
        {
            _adminService.LoadAdmins();
            _studentService.LoadStudents();
            _courseService.LoadCourses();
            _enrollmentService.LoadEnrollments();

            while (true)
            {
                try
                {
                    Console.WriteLine("=== School Admin Menu ===");
                    Console.WriteLine("1. Register Admin");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Logout");
                    Console.WriteLine("4. Manage Students");
                    Console.WriteLine("5. Manage Courses");
                    Console.WriteLine("6. Manage Enrollments");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter choice: ");
                    string key = Console.ReadLine();

                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            _adminService.RegisterAdmin();
                            break;
                        case "2":
                            Console.Clear();
                            _adminService.Login();
                            break;
                        case "3":
                            Console.Clear();
                            _adminService.Logout();
                            break;
                        case "4":
                            Console.Clear();
                            StudentMenu.Start(_studentService);
                            break;
                        case "5":
                            Console.Clear();
                            CourseMenu.Start(_courseService);
                            break;
                        case "6":
                            Console.Clear();
                            EnrollmentMenu.Start(_enrollmentService, _studentService, _courseService);
                            break;
                        case "7":
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("Invalid option, try again.");
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