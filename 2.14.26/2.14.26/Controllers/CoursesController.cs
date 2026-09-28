using _2._14._26.Data;
using _2._14._26.DTOs;
using _2._14._26.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._14._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private DataContext DC;
        public CoursesController(DataContext db) => DC = db;

        [HttpGet]
        public IActionResult GetCourses() => Ok(DC.Courses.ToList());

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = DC.Courses.Find(id);
            return course == null ? NotFound($"Course {id} not found.") : Ok(course);
        }

        [HttpGet("filter/by-instructor")]
        public IActionResult FilterByInstructor(string instructor)
        {
            var result = DC.Courses.Where(c => c.Instructor
            .ToLower()
            .Contains(instructor
            .ToLower()))
            .ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseDto req)
        {
            var course = new Course
            {
                Title = req.Title,
                Credits = req.Credits,
                Instructor = req.Instructor
            };
            DC.Courses.Add(course);
            DC.SaveChanges();
            return Ok("Course created successfully!");
        }

        [HttpPost("update-title")]
        public IActionResult UpdateTitle(int id, string newTitle)
        {
            var course = DC.Courses.Find(id);
            if (course == null) return NotFound($"Course {id} not found.");
            course.Title = newTitle;
            DC.SaveChanges();
            return Ok("Title updated successfully!");
        }

        [HttpPost("search-by-credits")]
        public IActionResult SearchByCredits(int min, int max)
        {
            var result = DC.Courses
                .Where(c => c.Credits >= min && c.Credits <= max)
                .ToList();
            return Ok(result);
        }






    }
}
