using OneToOneHM5UniqueEx.Enums.VehicleRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.VehicleRegistrationModels
{
    internal class Registration
    {
        public int RegistrationId { get; set; }
        public string PlateNumber { get; set; }
        public DateTime RegisteredAt { get; set; }

        public RegistrationStatus Status { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
