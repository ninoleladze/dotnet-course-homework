using SocialMedia.Common;
using SocialMedia.DTOs;

namespace SocialMedia.Services.Posts
{
    public interface IPostService
    {
        Result<int> Create(int userId, CreatePostDto req);
        Result<int> Delete(int userId, int id);
        Result<int> Update(int userId, EditPostDto req);
        Result<List<GetPostDto>> GetPosts();
        Result<List<GetPostDto>> GetUserPosts(int userId);
    }
}
