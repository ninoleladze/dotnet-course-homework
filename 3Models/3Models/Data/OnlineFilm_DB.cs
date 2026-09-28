using _3Models.Models.OnlineFilm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Data
{
    internal class OnlineFilm_DB : DbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<ParentalControl> ParentalControls { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<WatchHistory> WatchHistories { get; set; }
        DbSet<Billing> Billings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=OnlineFilm_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
          
        }

    }
}
