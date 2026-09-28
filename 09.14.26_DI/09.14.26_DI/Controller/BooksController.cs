using Microsoft.AspNetCore.Mvc;
using _09._14._26_DI.Models;
using _09._14._26_DI.Requests.Book;

namespace _09._14._26_DI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new();

        [HttpGet] public IActionResult GetAll() => Ok(_books);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) =>
            _books.FirstOrDefault(b => b.Id == id) is Book book ? Ok(book) : NotFound();
        
        [HttpPost]
        public IActionResult Create(CreateBookRequest request)
        {
            var book = new Book
            {
                Id = _books.Count + 1,
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Price = request.Price
            };
            _books.Add(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateBookRequest request)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound();

            if (request.Title != null) book.Title = request.Title;
            if (request.Description != null) book.Description = request.Description;
            if (request.Author != null) book.Author = request.Author;
            if (request.Price.HasValue) book.Price = request.Price.Value;
            book.Updated = DateTime.Now;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound();
            _books.Remove(book);
            return NoContent();
        }
    }
}
