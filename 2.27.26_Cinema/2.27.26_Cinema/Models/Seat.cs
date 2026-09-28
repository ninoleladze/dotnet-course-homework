using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._27._26_Cinema.Models
{
    internal class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
