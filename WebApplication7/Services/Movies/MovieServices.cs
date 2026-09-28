using WebApplication7.Common;
using WebApplication7.Data;
using WebApplication7.DTOs;
using WebApplication7.Models;

namespace WebApplication7.Services.Movies
{
    public class MovieServices : IMovieServices
    {
        private DataContext _db;

        public MovieServices(DataContext db) => _db = db;

        public Result<int> CreateMovie(CreateMovieDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return Result<int>.BadRequest("Title is required.");
            }

            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return Result<int>.BadRequest("Description is required.");
            }

            if (dto.Duration < 10 || dto.Duration > 300)
            {
                return Result<int>.BadRequest("Duration must be between 10 and 300 minutes.");
            }

            Movie movie = new Movie()
            {
                Title = dto.Title,
                Duration = dto.Duration,
                Description = dto.Description,
            };

            _db.Movies.Add(movie);
            _db.SaveChanges();

            return Result<int>.Ok(movie.Id);
        }

        public Result<int> DeleteMovie(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return Result<int>.NotFound("Movie not found.");

            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return Result<int>.Ok(movie.Id);
        }

        public Result<int> EditMovie(int id, EditMovieDto dto)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return Result<int>.NotFound("Movie not found.");
            if (!string.IsNullOrWhiteSpace(dto.Title)) 
                movie.Title = dto.Title;
            
            if (!string.IsNullOrWhiteSpace(dto.Description))
                movie.Description = dto.Description;
            
            if (dto.Duration.HasValue)
                movie.Duration = dto.Duration.Value;
            
            _db.SaveChanges();
            return Result<int>.Ok(movie.Id);
        }

        public Result<List<Movie>> GetMovies()
        {
            var movies = _db.Movies.ToList();
            return Result<List<Movie>>.Ok(movies);

        }
    }
}
