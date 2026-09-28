using OneToOneHM5UniqueEx.Enums.VehicleRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.VehicleRegistrationModels
{
    internal class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public CarType Type { get; set; }
        public FuelType Fuel { get; set; }

        public Registration Registration { get; set; }

    }
}
