using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>()
        {
            new Book(1, "Book 1", "This is the first book", "John Doe"),
            new Book(2, "Book 2", "This is the second book", "Jane Doe"),
            new Book(3, "Book 3", "This is the third book", "John Smith"),
            new Book(4, "Book 4", "This is the fourth book", "Jane Smith"),
            new Book(5, "Book 5", "This is the fifth book", "John Johnson"),
            new Book(6, "Book 6", "This is the sixth book", "Jane Johnson"),
            new Book(7, "Book 7", "This is the seventh book", "John Williams"),
            new Book(8, "Book 8", "This is the eighth book", "Jane Williams"),
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            return books;
        }

     
         [HttpGet("{id}")]
        public ActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("Book not found!");
            return Ok(book);

        }
      
        [HttpGet("filter/by-title")]
        public ActionResult Filter(string title)
        {
            var bookData = books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
            return Ok(bookData);
        }


        [HttpGet("filter/by-author")]
        public ActionResult FilterByAuthor(string author)
        {
            var bookData = books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
            return Ok(bookData);
        }
        
        [HttpGet("filter/by-description")]
        public ActionResult FilterByDescription(string description)
        {
            var bookData = books.Where(x => x.Description.ToLower().Contains(description.ToLower())).ToList();
            return Ok(bookData);


        }
    }
}