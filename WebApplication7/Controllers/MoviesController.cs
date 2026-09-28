using WebApplication7.Services.Movies;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.DTOs;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieServices _movies;

        public MoviesController(IMovieServices movies) => _movies = movies;

        [HttpPost]
        public IActionResult Create(CreateMovieDto dto)
        {
            var result = _movies.CreateMovie(dto);

            return StatusCode(result.Status, result);
        }

        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            var result = _movies.DeleteMovie(movieId);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{movieId}")]
        public IActionResult Edit(int movieId, EditMovieDto dto)
        {
            var result = _movies.EditMovie(movieId, dto);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _movies.GetMovies();
            return StatusCode(result.Status, result);
        }


    }
}
