using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        List<Book> Books = new List<Book>
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

        [HttpGet("byIndex/{index}")]
        public Book GetBookByIndex(int index)
        {
            return Books[index];
        }

        [HttpGet("byAuthor/{author}")]
        public List<Book> GetBooksByAuthor(string author)
        {
            return Books.Where(b => b.Author == author).ToList();
        }

        [HttpGet("topRated")]
        public Book GetTopRatedBook()
        {
            return Books.OrderByDescending(b => b.Rating).First();
        }

        [HttpGet("count")]
        public int GetBookCount()
        {
            return Books.Count;
        }
    }
}
