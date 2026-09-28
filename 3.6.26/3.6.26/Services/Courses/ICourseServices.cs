using _3._6._26.Common;
using _3._6._26.DTOs.Course;
using _3._6._26.Models;

namespace _3._6._26.Services.Courses
{
    public interface ICourseServices
    {
        Result<int> CreateCourse(CreateCourseDto dto);
        Result<int> UpdateCourse(int id, UpdateCourseDto dto);
        Result<int> DeleteCourse(int id);
        Result<List<Course>> GetCourses();
        Result<Course> GetCourseById(int id);
        Result<Course> GetCourseWithStudents(int id);
    }
}