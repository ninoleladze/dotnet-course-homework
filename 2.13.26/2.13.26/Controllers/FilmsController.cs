using _2._13._26.Data;
using _2._13._26.DTOs;
using _2._13._26.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace _2._13._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private DataContext DC;
        public FilmsController(DataContext db) => DC = db;


        [HttpGet]
        public IActionResult GetFilms()
        {
            var films = DC.Films.ToList();
            return Ok(films);
        }

        [HttpGet("{FilmId}")]
        public IActionResult GetProduct(int FilmId)
        {
            var film = DC.Films.Find(FilmId);
            if (film == null)
                return NotFound($"Film with id {FilmId} not found.");
            return Ok(film);
        }



        [HttpGet("filter/by-director")]
        public ActionResult FilterByDirector(string director)
        {
            var FilmsData = DC.Films.Where(x => x.Director.ToLower().Contains(director.ToLower())).ToList();

            return Ok(FilmsData);
        }


       
        [HttpPost]
        public IActionResult CreateFilm(CreateFilmDto req)
        {
            Film film = new Film
            {
                Title = req.Title,
                Director = req.Director,
                ReleaseYear = req.ReleaseYear,
                Genre = req.Genre
            };
            DC.Films.Add(film);
            DC.SaveChanges();
            return Ok("Success!");



        }
        [HttpPost("add-title")]
        public IActionResult AddTitle(int filmId, string newTitle)
        {
            var film = DC.Films.Find(filmId);
            if (film == null)
                return NotFound($"Film with id {filmId} not found.");
            film.Title = newTitle;
            DC.SaveChanges();
            return Ok("Title updated successfully!");
        }





    }
}
