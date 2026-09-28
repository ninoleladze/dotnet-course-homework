using Test.Models;
using System.Text.Json;

namespace Test.Services
{
    internal class EnrollmentService
    {
        private List<(int StudentId, int CourseId)> enrollments = new List<(int, int)>();
        private string path = "enrollments.json";

        public void LoadEnrollments()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<(int StudentId, int CourseId)>>(json);
                if (data != null) enrollments = data;
            }
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            enrollments.Add((studentId, courseId));
            SaveData();
            Console.WriteLine($"Student {studentId} enrolled in course {courseId}");
        }

        public void ShowEnrollments()
        {
            if (!enrollments.Any()) throw new Exception("No enrollments found");
            foreach (var e in enrollments)
                Console.WriteLine($"StudentId={e.StudentId}, CourseId={e.CourseId}");
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(enrollments);
            File.WriteAllText(path, json);
        }
    }
}