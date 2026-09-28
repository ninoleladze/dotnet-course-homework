using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hospital
{
    internal class Specialization
    {
        public int Id { get; set; }
        public string Title { get; set; } 

        public List<Doctor> Doctors { get; set; } = new();
    }
}
