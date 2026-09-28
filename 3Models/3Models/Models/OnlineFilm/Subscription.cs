using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.OnlineFilm
{
    internal class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public double MonthlyPrice { get; set; }
        public List<User> Subscribers { get; set; }
    }
}
