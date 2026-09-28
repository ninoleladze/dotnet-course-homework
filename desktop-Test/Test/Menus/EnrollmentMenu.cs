using Test.Services;
using System;

namespace Test.Menus
{
    internal class EnrollmentMenu
    {
        public static void Start(EnrollmentService enrollmentService, StudentService studentService, CourseService courseService)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("=== Enrollment Menu ===");
                    Console.WriteLine("1. Enroll Student to Course");
                    Console.WriteLine("2. Show Enrollments");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter choice: ");
                    string key = Console.ReadLine();

                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            studentService.ShowStudents();
                            Console.WriteLine("Enter student id:");
                            int studentId = int.Parse(Console.ReadLine());

                            courseService.ShowCourses();
                            Console.WriteLine("Enter course id:");
                            int courseId = int.Parse(Console.ReadLine());

                            enrollmentService.EnrollStudent(studentId, courseId);
                            break;
                        case "2":
                            Console.Clear();
                            enrollmentService.ShowEnrollments();
                            break;
                        case "3":
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