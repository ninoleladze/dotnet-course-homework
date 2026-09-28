using _2._14._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._14._26.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
