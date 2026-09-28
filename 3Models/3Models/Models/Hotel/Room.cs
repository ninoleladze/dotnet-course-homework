using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType Type { get; set; }

        public List<CleaningLog> CleaningHistory { get; set; } = new();
        public List<Amenity> Amenities { get; set; } = new();
    }
}
