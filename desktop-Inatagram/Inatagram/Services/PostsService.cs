using Inatagram.Models;

namespace Inatagram.Services
{
    internal class PostsService
    {
        private Baza baza = new Baza();

        public void CreatePost()
        {
            if (UsersService.LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("title is required.");

            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
                throw new Exception("description is required.");

            var post = new Post
            {
                Title = title,
                Description = description
            };

            baza.Posts.Add(post);
            baza.SaveChanges();

            Console.WriteLine("post created successfully.");
        }
        public void DeletePost()
        {
            if (UsersService.LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Enter post id to delete: ");
            string idStr = Console.ReadLine();
            if (!int.TryParse(idStr, out int id))
                throw new Exception("invalid id.");

            var post = baza.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new Exception("post not found.");

            baza.Posts.Remove(post);
            baza.SaveChanges();

            Console.WriteLine("post deleted.");
        }
        public void EditPost()
        {
            if (UsersService.LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Enter post id to edit: ");
            string idStr = Console.ReadLine();
            if (!int.TryParse(idStr, out int id))
                throw new Exception("invalid id.");

            var post = baza.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new Exception("post not found.");

            Console.Write($"Enter new title (leave empty to keep '{post.Title}'): ");
            string newTitle = Console.ReadLine();
            Console.Write($"Enter new description (leave empty to keep current): ");
            string newDesc = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTitle))
                post.Title = newTitle;
            if (!string.IsNullOrWhiteSpace(newDesc))
                post.Description = newDesc;

            baza.SaveChanges();

            Console.WriteLine("post updated successfully.");
        }
        public void GetAllPosts()
        {
            var posts = baza.Posts.ToList();
            if (posts.Count == 0)
            {
                Console.WriteLine("no posts available.");
                return;
            }

            foreach (var p in posts)
            {
                Console.WriteLine($"ID: {p.Id}, Title: {p.Title}, Description: {p.Description}, Likes: {p.Likes}");
            }
        }
        public void GetPostById()
        {
            Console.Write("Enter post id: ");
            string idStr = Console.ReadLine();
            if (!int.TryParse(idStr, out int id))
                throw new Exception("invalid id.");

            var post = baza.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new Exception("post not found.");

            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Description: {post.Description}, Likes: {post.Likes}");
        }
        public void Filter()
        {
            Console.Write("Enter keyword to filter by title or description: ");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
                throw new Exception("keyword is required.");

            var results = baza.Posts
                .Where(p => p.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("no posts matched the filter.");
                return;
            }

            foreach (var p in results)
            {
                Console.WriteLine($"ID: {p.Id}, Title: {p.Title}, Description: {p.Description}, Likes: {p.Likes}");
            }
        } 
      
        public void LikePost()
        {
            if (UsersService.LoggedInUser == null)
                throw new Exception("Unauthorized.");

            Console.Write("Enter post id to like: ");
            string idStr = Console.ReadLine();
            if (!int.TryParse(idStr, out int id))
                throw new Exception("invalid id.");

            var post = baza.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new Exception("post not found.");

            post.Likes += 1;
            baza.SaveChanges();

            Console.WriteLine($"post liked. total likes: {post.Likes}");
        }
    }
}
