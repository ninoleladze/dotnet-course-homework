using _2._17._26.Data;
using _2._17._26.DTOs;
using _2._17._26.Models;
using _2._17._26.Services.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._17._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase 
    {
        private IPostServices _postServices;
        public PostController (IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var result = _postServices.GetPosts();
       
            return Ok(result);

        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostDto req)
        {

            var result = _postServices.CreatePost(req);
            return Ok(result);

        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {

            var result = _postServices.DeletePost(postId);
            return Ok(result);
           

        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, UpdatePostDto req)
        {
            var result = _postServices.EditPost(postId, req);
            return Ok(result);

        }










    }
}
