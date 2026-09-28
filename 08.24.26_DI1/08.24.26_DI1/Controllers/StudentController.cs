using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> Students = new List<Student>
        {
            new Student() { Name = "David", GPA = 3.5 },
            new Student() { Name = "Emma", GPA = 3.9 },
            new Student() { Name = "Frank", GPA = 2.8 }
        };

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return Students;
        }

        [HttpGet("byIndex/{index}")]
        public Student GetStudentByIndex(int index)
        {
            return Students[index];
        }

        [HttpGet("byName/{name}")]
        public List<Student> GetStudentsByName(string name)
        {
            return Students.Where(s => s.Name == name).ToList();
        }

        [HttpGet("topGPA")]
        public Student GetTopStudent()
        {
            return Students.OrderByDescending(s => s.GPA).First();
        }

        [HttpGet("count")]
        public int GetStudentCount()
        {
            return Students.Count;
        }
    }
}
