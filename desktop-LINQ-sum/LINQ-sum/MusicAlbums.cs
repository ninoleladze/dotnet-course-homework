using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_sum
{
    internal class MusicAlbums: IMusicAlbums
    {
        List<Band> bands = new List<Band>()
            {
                new Band { BandName = "Queen", Genre = "Rock", SongName = "Bohemian Rhapsody", Year = 1975 },
                new Band { BandName = "The Beatles", Genre = "Pop Rock", SongName = "Hey Jude", Year = 1968 },
                new Band { BandName = "Metallica", Genre = "Heavy Metal", SongName = "Enter Sandman", Year = 1991 },
                new Band { BandName = "Nirvana", Genre = "Grunge", SongName = "Smells Like Teen Spirit", Year = 1991 },
                new Band { BandName = "Coldplay", Genre = "Alternative Rock", SongName = "Yellow", Year = 2000 },
                new Band { BandName = "Imagine Dragons", Genre = "Pop Rock", SongName = "Believer", Year = 2017 },
                new Band { BandName = "AC/DC", Genre = "Hard Rock", SongName = "Back in Black", Year = 1980 },
                new Band { BandName = "Linkin Park", Genre = "Nu Metal", SongName = "In the End", Year = 2001 },
                new Band { BandName = "Pink Floyd", Genre = "Progressive Rock", SongName = "Another Brick in the Wall", Year = 1979 },
                new Band { BandName = "Maroon 5", Genre = "Pop", SongName = "Sugar", Year = 2015 }
            };

        public void addAlbum()
        {
            Console.WriteLine("Enter Band Name:");
            string bandName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bandName)) throw new Exception("Band Name cannot be empty.");
            Console.WriteLine("Enter Genre:");
            string genre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(genre)) throw new Exception("Genre cannot be empty.");
            Console.WriteLine("Enter Song Name:");
            string songName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(songName)) throw new Exception("Song Name cannot be empty.");
            Console.WriteLine("Enter Year:");
     
            int year= Convert.ToInt32(Console.ReadLine());
            if (year < 1900 || year > DateTime.Now.Year) throw new Exception("Year is out of valid range.");

            Band newBand = new Band
            {
                BandName = bandName,
                Genre = genre,
                SongName = songName,
                Year = year
            };
            bands.Add(newBand);
            Console.WriteLine("Album added successfully.");

        }

        public void deleteAlbum()
        {
            displayAlbums();
            Console.WriteLine("enter album id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var bandToDelete = bands.FirstOrDefault(b => b.Id == id);
            if (bandToDelete == null)throw new Exception("Album with the specified ID does not exist.");

            bands.Remove(bandToDelete);
            Console.WriteLine("Album deleted successfully.");
        }

        public void displayAlbums()
        {
       
            Console.WriteLine("Albums:");
          foreach (var band in bands)
            {
                Console.WriteLine(band);
            }
        }

        public void filterAlbumsByBandName()
        {
            displayAlbums();
            Console.WriteLine("find band by name");
            string bandName = Console.ReadLine();
            var filteredBands = bands.Where(b => b.BandName.ToLower().Contains(bandName.ToLower()))
                               .ToList();
            if(!filteredBands.Any())throw new Exception("No albums found for the specified band name.");
            foreach (var band in filteredBands)
            {
                Console.WriteLine(band);
            }

        }

        public void filterAlbumsByGenre()
        {
            displayAlbums();
            Console.WriteLine("find band by genre");
            string genre = Console.ReadLine();
            var filteredBands = bands.Where(b => b.Genre.ToLower().Contains(genre.ToLower()))
                               .ToList();
            if (!filteredBands.Any()) throw new Exception("No albums found for the specified genre.");
            foreach (var band in filteredBands)
            {
                Console.WriteLine(band);
            }


        }

        public void filterAlbumsByGenreByYear()
        {
            displayAlbums();
            Console.WriteLine("find band by genre");
            string genre = Console.ReadLine();
            Console.WriteLine("enter year");
            int year = Convert.ToInt32(Console.ReadLine());
            var filteredBands = bands.Where(b => b.Genre.ToLower().Contains(genre.ToLower()) && b.Year == year)
                               .ToList();
            if (!filteredBands.Any()) throw new Exception("No albums found for the specified genre and year.");
            foreach (var band in filteredBands)
            {
                Console.WriteLine(band);
            }

        }

        public void filterAlbumsByYear()
        {
            
            displayAlbums();
            Console.WriteLine("enter year");
            int year = Convert.ToInt32(Console.ReadLine());
            var filteredBands = bands.Where(b => b.Year == year)
                               .ToList();
            if (!filteredBands.Any()) throw new Exception("No albums found for the specified year.");
            foreach (var band in filteredBands)
            {
                Console.WriteLine(band);
            }
        }

        public void getAlbumById()
        {
          
            displayAlbums();
            Console.WriteLine("enter album id to get:");
            int id = Convert.ToInt32(Console.ReadLine());
            var band = bands.FirstOrDefault(b => b.Id == id);
            if (band == null) throw new Exception("Album with the specified ID does not exist.");
            Console.WriteLine(band.ToString());
        }

        public void searchAlbum()
        {
            displayAlbums();
            Console.WriteLine("search album by band name, genre, song name or year:");
            string searchTerm = Console.ReadLine();
            var filteredBands = bands.Where(b => b.BandName.ToLower().Contains(searchTerm.ToLower()) ||
                                                 b.Genre.ToLower().Contains(searchTerm.ToLower()) ||
                                                 b.SongName.ToLower().Contains(searchTerm.ToLower()) ||
                                                 b.Year.ToString() == searchTerm)
                               .ToList();
            if (!filteredBands.Any()) throw new Exception("No albums found matching the search term.");
            foreach (var band in filteredBands)
            {
                Console.WriteLine(band);
            }
        }

        public void updateAlbum()
        {
            displayAlbums();
            Console.WriteLine("enter album id to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var bandToUpdate = bands.FirstOrDefault(b => b.Id == id);
            if (bandToUpdate == null) throw new Exception("Album with the specified ID does not exist.");
            Console.WriteLine("Enter new Band Name (leave blank to keep current):");
            string bandName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(bandName))
            {
                bandToUpdate.BandName = bandName;
            }
            Console.WriteLine("Enter new Genre (leave blank to keep current):");
            string genre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genre))
            {
                bandToUpdate.Genre = genre;
            }
            Console.WriteLine("Enter new Song Name (leave blank to keep current):");
            string songName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(songName))
            {
                bandToUpdate.SongName = songName;
            }
            Console.WriteLine("Enter new Year (leave blank to keep current):");
            string yearInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                int year = Convert.ToInt32(yearInput);
                if (year < 1950 || year > DateTime.Now.Year) throw new Exception("Year is out of valid range.");
                bandToUpdate.Year = year;
            }
            Console.WriteLine("Album updated successfully.");
        }
    }
}
