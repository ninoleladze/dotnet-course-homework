using _3._6._26.Common;
using _3._6._26.DTOs.Student;
using _3._6._26.Models;

namespace _3._6._26.Services.Students
{
    public interface IStudentServices
    {
        Result<int> CreateStudent(CreateStudentDto dto);
        Result<int> UpdateStudent(int id, UpdateStudentDto dto);
        Result<int> DeleteStudent(int id);
        Result<List<Student>> GetStudents();
        Result<Student> GetStudentById(int id);
        Result<Student> GetStudentWithCourses(int id);
    }
}