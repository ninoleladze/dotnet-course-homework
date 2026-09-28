using _3._6._26.Common;
using _3._6._26.Data;
using _3._6._26.DTOs.Student;
using _3._6._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._6._26.Services.Students
{
    public class StudentServices : IStudentServices
    {
        private DataContext _db;
        public StudentServices(DataContext db) => _db = db;

        public Result<int> CreateStudent(CreateStudentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                return Result<int>.BadRequest("Username is required.");
            var student = new Student { Username = dto.Username, FirstName = dto.FirstName, LastName = dto.LastName };
            _db.Students.Add(student);
            _db.SaveChanges();
            return Result<int>.Ok(student.Id);
        }

        public Result<int> UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = _db.Students.Find(id);
            if (student == null) return Result<int>.NotFound("Student not found.");
            if (!string.IsNullOrWhiteSpace(dto.Username)) student.Username = dto.Username;
            if (!string.IsNullOrWhiteSpace(dto.FirstName)) student.FirstName = dto.FirstName;
            if (!string.IsNullOrWhiteSpace(dto.LastName)) student.LastName = dto.LastName;
            _db.SaveChanges();
            return Result<int>.Ok(student.Id);
        }

        public Result<int> DeleteStudent(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null) return Result<int>.NotFound("Student not found.");
            _db.Students.Remove(student);
            _db.SaveChanges();
            return Result<int>.Ok(student.Id);
        }

        public Result<List<Student>> GetStudents()
        {
            var students = _db.Students.ToList();
            return Result<List<Student>>.Ok(students);
        }

        public Result<Student> GetStudentById(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null) return Result<Student>.NotFound("Student not found.");
            return Result<Student>.Ok(student);
        }

        public Result<Student> GetStudentWithCourses(int id)
        {
            var student = _db.Students.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefault(s => s.Id == id);
            if (student == null) return Result<Student>.NotFound("Student not found.");
            return Result<Student>.Ok(student);
        }
    }
}