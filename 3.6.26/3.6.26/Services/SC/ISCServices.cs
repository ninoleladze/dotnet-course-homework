using _3._6._26.Common;
using _3._6._26.DTOs.SC;
using _3._6._26.Models;

namespace _3._6._26.Services.StudentCourses
{
    public interface IStudentCoursesService
    {
        Result<int> EnrollStudent(CreateSCDto dto);
        Result<int> UpdateEnrollment(int id, UpdateSCDto dto);
        Result<int> RemoveEnrollment(int id);
        Result<List<Models.StudentCourses>> GetEnrollments();
        Result<Models.StudentCourses> GetEnrollmentById(int id);
    }
}