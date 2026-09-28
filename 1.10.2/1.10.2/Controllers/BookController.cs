using _1._10._2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace _1._10._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private DataContext DC;
        public BookController(DataContext db) => DC = db;



        [HttpGet]
        public List<Book> GetBooks()
        {
            var books = DC.Books.ToList();
            return books;
        }


        [HttpGet("{BookId}")]
        public ActionResult GetPostById(int BookId)
        {
            var book = DC.Books.Find(BookId);
            if (book == null)
                return NotFound("Book not found");
            return Ok(book);
        }

    }
}
