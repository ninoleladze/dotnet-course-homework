using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private static List<Post>posts = new List<Post>() { 
        
            new Post("First Post", "This is the first post", "John Doe"),
            new Post("Second Post", "This is the second post", "Jane Doe"),
            new Post("Third Post", "This is the third post", "John Smith"),
            new Post("Fourth Post", "This is the fourth post", "Jane Smith"),
            new Post("Fifth Post", "This is the fifth post", "John Johnson"),
            new Post("Sixth Post", "This is the sixth post", "Jane Johnson"),
            new Post("Seventh Post", "This is the seventh post", "John Williams"),
            new Post("Eighth Post", "This is the eighth post", "Jane Williams"),


        };


        [HttpGet]
        public List<Post> GetNames()
        {
            return posts;
        }


        [HttpGet("{postId}")]
        public ActionResult GetPostById(int postId)
        {
            var post = posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return NotFound("post not found!");
            return Ok(post);
        }


        [HttpGet("filter/by-title")]
        public ActionResult Filter (string title)
        {
            var postData = posts.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();

            return Ok(postData);
        }

    }
}
