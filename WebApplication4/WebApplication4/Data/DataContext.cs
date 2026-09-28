using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

      
    }
}
