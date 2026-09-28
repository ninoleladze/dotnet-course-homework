using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
