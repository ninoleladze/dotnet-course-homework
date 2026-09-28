using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.OnlineFilm
{
    internal class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Billing Billing { get; set; }      
        public ParentalControl Controls { get; set; }   
        public List<WatchHistory> Histories { get; set; } 
        public List<Review> Reviews { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Plan { get; set; }
    }
}
