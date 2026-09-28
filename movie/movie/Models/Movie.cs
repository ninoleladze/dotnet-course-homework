using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        override public string ToString()
        {
            return $"{Title} directed by {Director}, released on {ReleaseDate.ToShortDateString()}. Description: {Description}";
        }
    }
}
