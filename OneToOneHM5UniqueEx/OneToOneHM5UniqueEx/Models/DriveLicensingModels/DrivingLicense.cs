using OneToOneHM5UniqueEx.Enums.DriveLicensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.DriveLicensingModels
{
    internal class DrivingLicense
    {
        public int DrivingLicenseId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime ExpiryDate { get; set; }

        public LicenseCategory Category { get; set; }
        public LicenseStatus Status { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

    }
}
