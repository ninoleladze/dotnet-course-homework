using _09._14._26_DI.Models;
using _09._14._26_DI.Requests.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _09._14._26_DI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new();

        [HttpGet] public IActionResult GetAll() => Ok(_movies);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) =>
            _movies.FirstOrDefault(m => m.Id == id) is Movie movie ? Ok(movie) : NotFound();

        [HttpPost]
        public IActionResult Create(CreateMovieRequest request)
        {
            var movie = new Movie
            {
                Id = _movies.Count + 1,
                Title = request.Title,
                Description = request.Description,
                Director = request.Director,
                Rating = request.Rating
            };
            _movies.Add(movie);
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateMovieRequest request)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie is null) return NotFound();

            if (request.Title != null) movie.Title = request.Title;
            if (request.Description != null) movie.Description = request.Description;
            if (request.Director != null) movie.Director = request.Director;
            if (request.Rating.HasValue) movie.Rating = request.Rating.Value;
            movie.Updated = DateTime.Now;

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie is null) return NotFound();
            _movies.Remove(movie);
            return NoContent();
        }
    }
}
