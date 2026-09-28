using Microsoft.EntityFrameworkCore;

namespace _2._27._26.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
