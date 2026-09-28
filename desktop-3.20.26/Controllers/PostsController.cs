using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs.PostDtos;
using SocialMedia.Services.Posts;
using System.Security.Claims;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IPostServices _postService;

        public PostsController(IPostServices postService) => _postService = postService;

        [HttpPost]
        [Authorize]
        public IActionResult CreatePost(CreatePostDto req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var result = _postService.Create(int.Parse(userId), req);
            return StatusCode(result.Status, result);
        }



        [HttpPut]
        [Authorize]
        public IActionResult UpdatePost(UpdatePostDto req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var result = _postService.Update(int.Parse(userId), req);
            return StatusCode(result.Status, result);
        }


        [HttpDelete("{Id}")]
        [Authorize]
        public IActionResult Delete(int id) {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var result = _postService.Delete(int.Parse(userId), id);
            return StatusCode(result.Status, result);
        }


        [HttpGet]
        public IActionResult GetPosts() {
            var result = _postService.GetPosts();
            return StatusCode(result.Status, result);
        }


        [HttpGet("user")]
        [Authorize]
        public IActionResult GetUserPosts()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var result = _postService.GetUserPosts(int.Parse(userId));
            return StatusCode(result.Status, result);
        } 






        }
}
