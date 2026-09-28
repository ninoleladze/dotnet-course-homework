using _3._6._26.DTOs.Course;
using _3._6._26.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace _3._6._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseServices _courses;
        public CourseController(ICourseServices courses) => _courses = courses;

        [HttpPost]
        public IActionResult Create(CreateCourseDto dto)
        {
            var result = _courses.CreateCourse(dto);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCourseDto dto)
        {
            var result = _courses.UpdateCourse(id, dto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _courses.DeleteCourse(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _courses.GetCourses();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _courses.GetCourseById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}/students")]
        public IActionResult GetWithStudents(int id)
        {
            var result = _courses.GetCourseWithStudents(id);
            return StatusCode(result.Status, result);
        }
    }
}