using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Models.Models.OnlineFilm
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Actor> Cast { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
