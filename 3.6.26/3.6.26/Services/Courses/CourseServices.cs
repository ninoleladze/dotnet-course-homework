using _3._6._26.Common;
using _3._6._26.Data;
using _3._6._26.DTOs.Course;
using _3._6._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._6._26.Services.Courses
{
    public class CourseServices : ICourseServices
    {
        private  DataContext _db;
        public CourseServices(DataContext db) => _db = db;

        public Result<int> CreateCourse(CreateCourseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return Result<int>.BadRequest("Title is required.");
            var course = new Course { Title = dto.Title, Description = dto.Description };
            _db.Courses.Add(course);
            _db.SaveChanges();
            return Result<int>.Ok(course.Id);
        }

        public Result<int> UpdateCourse(int id, UpdateCourseDto dto)
        {
            var course = _db.Courses.Find(id);
            if (course == null) return Result<int>.NotFound("Course not found.");
            if (!string.IsNullOrWhiteSpace(dto.Title)) course.Title = dto.Title;
            if (!string.IsNullOrWhiteSpace(dto.Description)) course.Description = dto.Description;
            _db.SaveChanges();
            return Result<int>.Ok(course.Id);
        }

        public Result<int> DeleteCourse(int id)
        {
            var course = _db.Courses.Find(id);
            if (course == null) return Result<int>.NotFound("Course not found.");
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return Result<int>.Ok(course.Id);
        }

        public Result<List<Course>> GetCourses()
        {
            var courses = _db.Courses.ToList();
            return Result<List<Course>>.Ok(courses);
        }

        public Result<Course> GetCourseById(int id)
        {
            var course = _db.Courses.Find(id);
            if (course == null) return Result<Course>.NotFound("Course not found.");
            return Result<Course>.Ok(course);
        }

        public Result<Course> GetCourseWithStudents(int id)
        {
            var course = _db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).FirstOrDefault(c => c.Id == id);
            if (course == null) return Result<Course>.NotFound("Course not found.");
            return Result<Course>.Ok(course);
        }
    }
}