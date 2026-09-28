using _2._27._26_Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._27._26_Cinema.Data
{
    internal class DataContext : DbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ShowTime> Showtimes { get; set; }
        DbSet<Hall> Halls { get; set; }
        DbSet<Seat> Seats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Cinema.2.27_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
