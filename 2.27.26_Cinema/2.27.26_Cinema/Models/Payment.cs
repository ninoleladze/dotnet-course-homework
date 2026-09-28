using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._27._26_Cinema.Models
{
    internal class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentTime { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
