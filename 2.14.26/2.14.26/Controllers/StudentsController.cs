using _2._14._26.Data;
using _2._14._26.DTOs;
using _2._14._26.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._14._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private DataContext DC;
        public StudentsController(DataContext db) => DC = db;

        [HttpGet]
        public IActionResult GetStudents() => Ok(DC.Students.ToList());

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = DC.Students.Find(id);
            return student == null ? NotFound($"Student {id} not found.") : Ok(student);
        }

        [HttpGet("filter/by-major")]
        public IActionResult FilterByMajor(string major)
        {
            var result = DC.Students
                .Where(s => s.Major
                .ToLower()
                .Contains(major
                .ToLower()))
                .ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto req)
        {
            var student = new Student
            {
                FullName = req.FullName,
                Age = req.Age,
                Major = req.Major
            };
            DC.Students.Add(student);
            DC.SaveChanges();
            return Ok("Student created successfully!");
        }

        [HttpPost("update-name")]
        public IActionResult UpdateName(int id, string newName)
        {
            var student = DC.Students.Find(id);
            if (student == null)
                return NotFound($"Student {id} not found.");
            student.FullName = newName;
            DC.SaveChanges();
            return Ok("Name updated successfully!");
        }
        [HttpPost("search-by-age")]
        public IActionResult SearchByAge(int min, int max)
        {
            var result = DC.Students
                .Where(s => s.Age >= min && s.Age <= max)
                .ToList();
            return Ok(result);
        }
    }
}
