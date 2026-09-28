using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class CleaningLog
    {
        public int Id { get; set; }
        public DateTime CleanedOn { get; set; }
        public string StaffName { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
