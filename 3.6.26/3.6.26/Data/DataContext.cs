using _3._6._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._6._26.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

       
    }
}
