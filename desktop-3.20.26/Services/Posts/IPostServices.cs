using SocialMedia.Common;
using SocialMedia.DTOs.PostDtos;

namespace SocialMedia.Services.Posts
{
    public interface IPostServices
    {
         Result<int> Create(int userId,CreatePostDto req);
        Result<int> Delete(int userId,int id);
        Result<int> Update(int userId,UpdatePostDto req);
        Result<List<GetPostDto>> GetPosts();
        Result<List<GetPostDto>> GetUserPosts(int userId);



    }
}
