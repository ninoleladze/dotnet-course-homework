using SocialMedia.Common;
using SocialMedia.Data;
using SocialMedia.DTOs.PostDtos;
using SocialMedia.Models;

namespace SocialMedia.Services.Posts
{
    public class PostServices : IPostServices
    {
        private readonly DataContext _db;
        public PostServices(DataContext db) =>   _db = db;
        public Result<int> Create(int userId, CreatePostDto req)
        {
            var user = _db.Users.Find(userId);
            if (user == null) 
                return Result<int>.NotFound("User not found");

            if(string.IsNullOrWhiteSpace(req.Title))
                return Result<int>.BadRequest("Title is required");
            if(string.IsNullOrWhiteSpace(req.Content))
                return Result<int>.BadRequest("Content is required");
            if(string.IsNullOrWhiteSpace(req.ImageUrl))
                return Result<int>.BadRequest("ImageUrl is required");

            Post post = new Post() { 
            
                UserId = userId,
                Title = req.Title,
                Content = req.Content,
                ImageUrl = req.ImageUrl,
            };
            _db.Posts.Add(post);
            _db.SaveChanges();
            return Result<int>.Ok(post.Id);


        }

        public Result<int> Delete(int userId, int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) 
                return Result<int>.NotFound("User not found");
            var post = _db.Posts.Find(id);
            if (post == null) 
                return Result<int>.NotFound("Post not found");

            if(post.UserId != userId)
                return Result<int>.BadRequest("You can only delete your own posts");
            post.IsDeleted = true;
            _db.SaveChanges();
            return Result<int>.Ok(post.Id);


        }
        public Result<int> Update(int userId, UpdatePostDto req)
        {
            var user = _db.Users.Find(userId);
            if (user == null) 
                return Result<int>.NotFound("User not found");
            var post = _db.Posts.Find(req.Id);
            if (post == null) 
                return Result<int>.NotFound("Post not found");
            if(post.UserId != userId)
                return Result<int>.BadRequest("You can only update your own posts");
            if(!string.IsNullOrWhiteSpace(req.Title))
                post.Title = req.Title;
            if(!string.IsNullOrWhiteSpace(req.Content))
                post.Content = req.Content;
            if(!string.IsNullOrWhiteSpace(req.ImageUrl))
                post.ImageUrl = req.ImageUrl;
            _db.SaveChanges();
            return Result<int>.Ok(post.Id);
        }

        public Result<List<GetPostDto>> GetPosts()
        {
            var posts = _db.Posts
                .Select(p => new GetPostDto() { 
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl
                })
                .ToList();
            return Result<List<GetPostDto>>.Ok(posts);

        }

        public Result<List<GetPostDto>> GetUserPosts(int userId)
        {
            var posts = _db.Posts
                .Where(p => p.UserId == userId)
                .Select(p => new GetPostDto() { 
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl
                })
                .ToList();
            return Result<List<GetPostDto>>.Ok(posts);

        }


      
    }
}
