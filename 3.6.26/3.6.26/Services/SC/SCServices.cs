using _3._6._26.Common;
using _3._6._26.Data;
using _3._6._26.DTOs.SC;
using _3._6._26.Models;

namespace _3._6._26.Services.StudentCourses
{
    public class StudentCoursesService : IStudentCoursesService
    {
        private  DataContext _db;
        public StudentCoursesService(DataContext db) => _db = db;

        public Result<int> EnrollStudent(CreateSCDto dto)
        {
            var student = _db.Students.Find(dto.StudentId);
            var course = _db.Courses.Find(dto.CourseId);
            if (student == null) return Result<int>.NotFound("Student not found.");
            if (course == null) return Result<int>.NotFound("Course not found.");
            var enrollment = new Models.StudentCourses { StudentId = dto.StudentId, CourseId = dto.CourseId };
            _db.StudentCourses.Add(enrollment);
            _db.SaveChanges();
            return Result<int>.Ok(enrollment.Id);
        }

        public Result<int> UpdateEnrollment(int id, UpdateSCDto dto)
        {
            var enrollment = _db.StudentCourses.Find(id);
            if (enrollment == null) return Result<int>.NotFound("Enrollment not found.");
            if (dto.StudentId.HasValue) enrollment.StudentId = dto.StudentId.Value;
            if (dto.CourseId.HasValue) enrollment.CourseId = dto.CourseId.Value;
            _db.SaveChanges();
            return Result<int>.Ok(enrollment.Id);
        }

        public Result<int> RemoveEnrollment(int id)
        {
            var enrollment = _db.StudentCourses.Find(id);
            if (enrollment == null) return Result<int>.NotFound("Enrollment not found.");
            _db.StudentCourses.Remove(enrollment);
            _db.SaveChanges();
            return Result<int>.Ok(enrollment.Id);
        }

        public Result<List<Models.StudentCourses>> GetEnrollments()
        {
            var enrollments = _db.StudentCourses.ToList();
            return Result<List<Models.StudentCourses>>.Ok(enrollments);
        }

        public Result<Models.StudentCourses> GetEnrollmentById(int id)
        {
            var enrollment = _db.StudentCourses.Find(id);
            if (enrollment == null) return Result<Models.StudentCourses>.NotFound("Enrollment not found.");
            return Result<Models.StudentCourses>.Ok(enrollment);
        }
    }
}