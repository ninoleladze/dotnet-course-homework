using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.OnlineFilm
{
    internal class WatchHistory
    {
        public int Id { get; set; }
        public DateTime DateWatched { get; set; }
        public int UserId { get; set; }
    }
}
