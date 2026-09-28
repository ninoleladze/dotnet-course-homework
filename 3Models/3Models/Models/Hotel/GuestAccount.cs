using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.Hotel
{
    internal class GuestAccount
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsCreditApproved { get; set; }
        public Guest Guest { get; set; }
    }
}
