using Microsoft.EntityFrameworkCore;

namespace _1._10._2.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
