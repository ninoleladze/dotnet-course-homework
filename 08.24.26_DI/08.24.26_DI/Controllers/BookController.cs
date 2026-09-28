using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _08._24._26_DI.Models;


namespace _08._24._26_DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        List<Book> Books = new List<Book>()
        {
            new Book() { Title = "Book 1", Author = "Author 1", Rating = 4.5 },
            new Book() { Title = "Book 2", Author = "Author 2", Rating = 3.8 },
            new Book() { Title = "Book 3", Author = "Author 3", Rating = 4.2 }
        };

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return Books;
        }

    }
}
