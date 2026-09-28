using OneToOneHM5UniqueEx.Enums.CitizenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneHM5UniqueEx.Models.CitizenManagementModels
{
    internal class Citizen
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Passport Passport { get; set; }
    }
}
