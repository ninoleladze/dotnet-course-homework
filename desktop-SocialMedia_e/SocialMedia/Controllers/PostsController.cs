using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Services.Posts;
using System.Security.Claims;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _post;

        public PostsController(IPostService post) => _post = post;

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreatePostDto req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var result = _post.Create(int.Parse(userId), req);

            return StatusCode(result.Status, result);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Edit(EditPostDto req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var result = _post.Update(int.Parse(userId), req);

            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var result = _post.Delete(int.Parse(userId), id);

            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var result = _post.GetPosts();

            return StatusCode(result.Status, result);
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult GetUserPosts()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var result = _post.GetUserPosts(int.Parse(userId));

            return StatusCode(result.Status, result);
        }
    }
}
