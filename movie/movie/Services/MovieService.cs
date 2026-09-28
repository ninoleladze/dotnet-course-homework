using movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.Services
{
    internal class MovieService
    {
        private Baza Baza = new Baza();
         
        Movie movie = new Movie();

        public void CreateMovie()
        {
            Console.WriteLine("Enter Movie title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) throw new Exception("Title is required");

            Console.WriteLine("Enter Movie director: ");
            string director = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(director)) throw new Exception("Director is required");

            Console.WriteLine("Enter Movie release date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();
            if (!DateTime.TryParse(dateInput, out DateTime releaseDate))
                throw new Exception("Valid release date is required");

            Console.WriteLine("Enter Movie description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description is required");

            var movie = new Movie()
            {
                Title = title,
                Director = director,
                ReleaseDate = releaseDate,
                Description = description
            };

            Baza.Set<Movie>().Add(movie);
            Baza.SaveChanges();
            Console.WriteLine("Movie created successfully!");
        }

        public void DeleteMovie()
        {
            Console.WriteLine("Enter Movie Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            var movie = Baza.Set<Movie>().Find(id);
            if (movie == null) throw new Exception("Movie not found");

            Baza.Set<Movie>().Remove(movie);
            Baza.SaveChanges();
            Console.WriteLine("Movie deleted successfully!");
        }

        public void EditMovie()
        {
            Console.WriteLine("Enter Movie Id to edit: ");
            int id = int.Parse(Console.ReadLine());
            var movie = Baza.Set<Movie>().Find(id);
            if (movie == null) throw new Exception("Movie not found");

            Console.WriteLine("Enter new title (leave blank to keep current): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                movie.Title = title;
            }

            Console.WriteLine("Enter new director (leave blank to keep current): ");
            string director = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(director))
            {
                movie.Director = director;
            }

            Console.WriteLine("Enter new release date (leave blank to keep current): ");
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime releaseDate))
            {
                movie.ReleaseDate = releaseDate;
            }

            Console.WriteLine("Enter new description (leave blank to keep current): ");
            string description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description))
            {
                movie.Description = description;
            }

            Baza.SaveChanges();
            Console.WriteLine("Movie updated successfully!");
        }

        public void ShowMovies()
        {
            var movies = Baza.Set<Movie>().ToList();
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}