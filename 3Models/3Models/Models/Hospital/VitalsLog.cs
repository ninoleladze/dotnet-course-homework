using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hospital
{
    internal class VitalsLog
    {
        public int Id { get; set; }
        public DateTime RecordedAt { get; set; }
        public string BloodPressure { get; set; }
        public double Temperature { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
