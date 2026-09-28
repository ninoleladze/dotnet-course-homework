using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public GuestAccount Account { get; set; }

        public List<Booking> Bookings { get; set; } = new();
    }
}
