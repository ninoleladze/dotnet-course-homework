using _2._20._26.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._20._26.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
