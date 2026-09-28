using _09._14._26_DI.Models;
using _09._14._26_DI.Requests.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _09._14._26_DI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new();

        [HttpGet] public IActionResult GetAll() => Ok(_students);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) =>
            _students.FirstOrDefault(s => s.Id == id) is Student student ? Ok(student) : NotFound();

        [HttpPost]
        public IActionResult Create(CreateStudentRequest request)
        {
            var student = new Student
            {
                Id = _students.Count + 1,
                Name = request.Name,
                Description = request.Description,
                Major = request.Major,
                Minor = request.Minor,
                GPA = request.GPA
            };
            _students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateStudentRequest request)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student is null) return NotFound();

            if (request.Name != null) student.Name = request.Name;
            if (request.Description != null) student.Description = request.Description;
            if (request.Major != null) student.Major = request.Major;
            if (request.Minor != null) student.Minor = request.Minor;
            if (request.GPA.HasValue) student.GPA = request.GPA.Value;
            student.Updated = DateTime.Now;

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student is null) return NotFound();
            _students.Remove(student);
            return NoContent();
        }
    }
}
