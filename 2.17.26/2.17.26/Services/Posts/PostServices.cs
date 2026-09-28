using _2._17._26.Data;
using _2._17._26.DTOs;
using _2._17._26.Models;

namespace _2._17._26.Services.Posts
{
    public class PostServices : IPostServices
    {
        private DataContext DC;
        public PostServices(DataContext db) => DC = db;

        public string CreatePost(CreatePostDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return "Post title is required.";
            if (string.IsNullOrWhiteSpace(req.Description))
                return "Post description is required.";
            if (string.IsNullOrWhiteSpace(req.Author))
                return "Post author is required.";

            var post = new Post
            {
                Title = req.Title,
                Description = req.Description,
                Author = req.Author

            };

            DC.Posts.Add(post);
            DC.SaveChanges();
            return "Post created successfully!";
        }

        public string DeletePost(int postId)
        {
            var post = DC.Posts.Find(postId);
            if (post == null) return "Post not found.";

            DC.Posts.Remove(post);
            DC.SaveChanges();

            return "Success";
        }

        public string EditPost(int postId, UpdatePostDto req)
        {

            var post = DC.Posts.Find(postId);
            if (post == null)
                return "Post not found.";

            if (!string.IsNullOrWhiteSpace(req.Title))
                post.Title = req.Title;
            if (!string.IsNullOrWhiteSpace(req.Description))
                post.Description = req.Description;
            if (!string.IsNullOrWhiteSpace(req.Author))
                post.Author = req.Author;

            DC.SaveChanges();

            return "Post updated successfully!";
        
        }

        public List<Post> GetPosts()
        {
            var posts = DC.Posts.ToList();

            return posts;
        }
    }
}
