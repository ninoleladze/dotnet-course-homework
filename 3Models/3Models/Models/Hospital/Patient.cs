using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hospital
{
    internal class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public MedicalPassport Passport { get; set; }
        public Insurance Insurance { get; set; }

        public List<VitalsLog> VitalsHistory { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
