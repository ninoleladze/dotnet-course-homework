using OneToOneHM5UniqueEx.Enums.CitizenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.CitizenManagementModels
{
    internal class Passport
    {
        public int PassportId { get; set; }
        public PassportStatus Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public string PassportNumber { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}
