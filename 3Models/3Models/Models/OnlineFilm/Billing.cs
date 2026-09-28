using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.OnlineFilm
{
    internal class Billing
    {
        public int Id { get; set; }
        public string CardToken { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
