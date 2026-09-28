using _2._17._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._17._26.Data
{
    public class DataContext  : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
