using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.DTOs;
using WebApplication4.Services.Books;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookServices _books;

        public BooksController(IBookServices books) => _books = books;

        [HttpPost]
        public IActionResult Create(CreateBookDto dto)
        {
            var result = _books.CreateBook(dto);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, UpdateBookDto dto)
        {
            var result = _books.EditBook(id, dto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _books.DeleteBook(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _books.GetBooks();
            return StatusCode(result.Status, result);
        }


    }
}
