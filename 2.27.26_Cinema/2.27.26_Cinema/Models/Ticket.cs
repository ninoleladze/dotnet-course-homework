using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._27._26_Cinema.Models
{
    internal class Ticket
    {
        public int Id { get; set; }
        public Double Price { get; set; }
        public DateTime PurchaseTime { get; set; }

        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        public Payment Payment { get; set; }
    }
}
