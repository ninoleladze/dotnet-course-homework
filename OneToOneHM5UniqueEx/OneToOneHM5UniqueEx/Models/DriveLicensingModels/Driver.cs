using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.DriveLicensingModels
{
    internal class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; }

        public DrivingLicense DrivingLicense { get; set; }

    }
}
