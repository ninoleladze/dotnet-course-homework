using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._27._26_Cinema.Models
{
    internal class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<ShowTime> ShowTimes { get; set; }
    }
}
