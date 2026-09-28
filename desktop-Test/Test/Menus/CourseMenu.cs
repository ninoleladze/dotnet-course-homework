using System;
using Test.Services;
using System;

namespace Test.Menus
{
    internal class CourseMenu
    {
        public static void Start(CourseService courseService)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("=== Course Menu ===");
                    Console.WriteLine("1. Create Course");
                    Console.WriteLine("2. Delete Course");
                    Console.WriteLine("3. Show Courses");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");
                    string key = Console.ReadLine();

                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            courseService.CreateCourse();
                            break;
                        case "2":
                            Console.Clear();
                            courseService.DeleteCourse();
                            break;
                        case "3":
                            Console.Clear();
                            courseService.ShowCourses();
                            break;
                        case "4":
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