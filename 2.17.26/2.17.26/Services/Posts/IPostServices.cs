using _2._17._26.DTOs;
using _2._17._26.Models;

namespace _2._17._26.Services.Posts
{
    public interface IPostServices
    {
        string CreatePost(CreatePostDto req);
        string DeletePost(int postId);
        string EditPost(int postId, UpdatePostDto req);
        List<Post> GetPosts();

    }
}
