using _3._10._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._10._26.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

   
    }
}
