using Test.Models;
using System.Text.Json;

namespace Test.Services
{
    internal class CourseService
    {
        private List<Course> coursesList = new List<Course>();
        private string path = "courses.json";

        public void LoadCourses()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<Course>>(json);
                if (data != null) coursesList = data;
            }
        }

        public void CreateCourse()
        {
            Console.WriteLine("Enter course title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) throw new Exception("Title is required");

            Console.WriteLine("Enter course description: ");
            string desc = Console.ReadLine();

            Course c = new Course()
            {
                Title = title,
                Description = desc
            };

            coursesList.Add(c);
            SaveData();
            Console.WriteLine("Course created successfully");
        }

        public void DeleteCourse()
        {
            ShowCourses();
            Console.WriteLine("Enter course id: ");
            int id = int.Parse(Console.ReadLine());

            var c = coursesList.FirstOrDefault(x => x.Id == id);
            if (c == null) throw new Exception("Course not found");

            coursesList.Remove(c);
            SaveData();
            Console.WriteLine("Course deleted successfully");
        }

        public void ShowCourses()
        {
            if (!coursesList.Any()) throw new Exception("No courses found");
            foreach (var c in coursesList) Console.WriteLine(c);
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(coursesList);
            File.WriteAllText(path, json);
        }
    }
}