using _3._6._26.DTOs.Student;
using _3._6._26.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace _3._6._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentServices _students;
        public StudentController(IStudentServices students) => _students = students;

        [HttpPost]
        public IActionResult Create(CreateStudentDto dto)
        {
            var result = _students.CreateStudent(dto);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateStudentDto dto)
        {
            var result = _students.UpdateStudent(id, dto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _students.DeleteStudent(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _students.GetStudents();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _students.GetStudentById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}/courses")]
        public IActionResult GetWithCourses(int id)
        {
            var result = _students.GetStudentWithCourses(id);
            return StatusCode(result.Status, result);
        }
    }
}