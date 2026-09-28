using SocialMedia.Common;
using SocialMedia.Data;
using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly DataContext _db;

        public PostService(DataContext db) => _db = db;

        public Result<int> Create(int userId, CreatePostDto req)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
                return Result<int>.NotFound("user not found.");

            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<int>.BadRequest("post title is required.");

            if (string.IsNullOrWhiteSpace(req.Content))
                return Result<int>.BadRequest("post title is required.");

            if (string.IsNullOrWhiteSpace(req.ImageUrl))
                return Result<int>.BadRequest("post title is required.");

            Post post = new Post()
            {
                ImageUrl = req.ImageUrl,
                Content = req.Content,
                Title = req.Title,
                UserId = userId,
            };

            _db.Posts.Add(post);
            _db.SaveChanges();

            return Result<int>.Ok(post.Id);
        }

        public Result<int> Delete(int userId, int id)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
                return Result<int>.NotFound("user not found.");

            var post = _db.Posts.Find(id);

            if (post == null)
                return Result<int>.NotFound("post not found.");

            if (post.UserId != userId)
                return Result<int>.BadRequest("this is not your post.");

            post.IsDeleted = true;
            _db.SaveChanges();

            return Result<int>.Ok(post.Id);
        }

        public Result<int> Update(int userId, EditPostDto req)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
                return Result<int>.NotFound("user not found.");

            var post = _db.Posts.Find(req.Id);

            if (post == null)
                return Result<int>.NotFound("post not found.");

            if (post.UserId != userId)
                return Result<int>.BadRequest("this is not your post.");

            if (!string.IsNullOrWhiteSpace(req.Title))
                post.Title = req.Title;

            if (!string.IsNullOrWhiteSpace(req.Content))
                post.Content = req.Content;

            if (!string.IsNullOrWhiteSpace(req.ImageUrl))
                post.ImageUrl = req.ImageUrl;

            _db.SaveChanges();

            return Result<int>.Ok(post.Id);
        }

        public Result<List<GetPostDto>> GetPosts()
        {
            var posts = _db.Posts
                .Select(p => new GetPostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                })
                .ToList();

            return Result<List<GetPostDto>>.Ok(posts);
        }

        public Result<List<GetPostDto>> GetUserPosts(int userId)
        {
            var posts = _db.Posts
                .Where(p => p.UserId == userId)
                .Select(p => new GetPostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                })
                .ToList();

            return Result<List<GetPostDto>>.Ok(posts);
        }
    }
}
