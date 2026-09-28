using Microsoft.EntityFrameworkCore;
using OneToOneHM5UniqueEx.Models.CitizenManagementModels;
using OneToOneHM5UniqueEx.Models.DriveLicensingModels;
using OneToOneHM5UniqueEx.Models.HotelManagementModels;
using OneToOneHM5UniqueEx.Models.OrderProcessingModels;
using OneToOneHM5UniqueEx.Models.VehicleRegistrationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Data
{
    internal class DataContext : DbContext
    {
        // dbsets for Citizen Management
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Passport> Passports { get; set; }
        //dbsets for Hotel Management
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<KeyCard> KeyCards { get; set; }
        // dbsets for driveLicensing 
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }

        //dbset for OrderProcessing
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        //DBSET fro vehicle registration
        public DbSet<Car> Cars { get; set; }
        public DbSet<Registration> Registrations { get; set; }



        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=OneToOneHM5UniqueEx_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
