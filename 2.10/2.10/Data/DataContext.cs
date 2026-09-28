using _2._10.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._10.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
