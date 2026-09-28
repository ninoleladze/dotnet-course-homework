using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_sum
{
    internal class Band  
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }
        public string BandName { get; set; }
        public string Genre { get; set; }
        public string SongName { get; set; }
        public int Year { get; set; }

        public Band()
        {
            Id= _idCounter++;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Band Name: {BandName}, Genre: {Genre}, Song Name: {SongName}, Year: {Year}";

        }
        }
}
