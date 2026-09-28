using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hospital
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Specialization> Specializations { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
