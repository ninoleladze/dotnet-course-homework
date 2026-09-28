using _2._10.Data;
using _2._10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private DataContext _context;
        public PostController(DataContext db) =>  _context = db;

        [HttpGet]
        public List<Post> GetPosts()
        {
            var posts =_context.Posts.ToList();
            return posts;

        }

        

      

    }
}
