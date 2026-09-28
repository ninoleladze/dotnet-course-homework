using _3._6._26.DTOs.SC;
using _3._6._26.Services.StudentCourses;
using Microsoft.AspNetCore.Mvc;

namespace _3._6._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private IStudentCoursesService _sc;
        public StudentCoursesController(IStudentCoursesService sc) => _sc = sc;

        [HttpPost]
        public IActionResult Enroll(CreateSCDto dto)
        {
            var result = _sc.EnrollStudent(dto);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateSCDto dto)
        {
            var result = _sc.UpdateEnrollment(id, dto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var result = _sc.RemoveEnrollment(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _sc.GetEnrollments();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _sc.GetEnrollmentById(id);
            return StatusCode(result.Status, result);
        }
    }
}