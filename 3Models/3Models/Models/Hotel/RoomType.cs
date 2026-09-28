using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class RoomType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal BasePrice { get; set; }

        public List<Room> Rooms { get; set; } = new();
    }
}
