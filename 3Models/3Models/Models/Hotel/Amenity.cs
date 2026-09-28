using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class Amenity
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public List<Room> Rooms { get; set; } = new();
    }
}
