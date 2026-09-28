using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class Booking
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
