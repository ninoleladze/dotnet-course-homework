using _1._20.Data;
using _1._20.Models;
using Microsoft.EntityFrameworkCore;



DataContext DC = new DataContext();

User? loggedInUser = null;

while (true)
{

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("1.register");
    Console.WriteLine("2.login");
    Console.WriteLine("3.logout");
    Console.WriteLine("4.create post");
    Console.WriteLine("5.delete post");
    Console.WriteLine("6.edit post");
    Console.WriteLine("7.show posts");
    Console.WriteLine("8.show my posts");
    Console.WriteLine("9.add comment");
    string choice = Console.ReadLine();
    Console.ResetColor();
    try
    {

        if (choice == "1")
        {
            Console.Clear();
            Console.WriteLine("enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("enter password:");
            string password = Console.ReadLine();


            User user = new User
            {
                Username = username,
                Email = email,
                Password = password

            };
            DC.Users.Add(user);
            DC.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("registered successfully");
            Console.ResetColor();

        }
        else if (choice == "2")
        {
            Console.Clear();
            Console.WriteLine("enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("enter password:");
            string password = Console.ReadLine();
            var user = DC.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null) throw new Exception("User not found.");
            Console.WriteLine(user);
            loggedInUser = user;
            Console.WriteLine("success");
        }
        else if (choice == "3")
        {
            
            if (loggedInUser == null) throw new Exception("You are not logged in.");
            loggedInUser = null;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("logged out successfully");
            Console.ResetColor();
        }
        else if (choice == "4")
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to create a post.");
            Console.Clear();
            Console.WriteLine("enter title:");
            string title = Console.ReadLine();
            Console.WriteLine("enter content:");
            string content = Console.ReadLine();
            Post post = new Post
            {
                Title = title,
                Content = content,
                UserId = loggedInUser.Id
            };
            DC.Posts.Add(post);
            DC.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("post created successfully");
            Console.ResetColor();
        }
        else if (choice == "5")
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to delete a post.");
            Console.Clear();
            Console.WriteLine("enter post id to delete:");
            int postId = int.Parse(Console.ReadLine());
            var post = DC.Posts.FirstOrDefault(p => p.Id == postId && p.UserId == loggedInUser.Id);
            if (post == null) throw new Exception("Post not found or you do not have permission to delete this post.");
            DC.Posts.Remove(post);
            DC.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("post deleted successfully");
            Console.ResetColor();
        }

        else if (choice == "6")
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to edit a post.");
            Console.Clear();
            Console.WriteLine("enter post id to edit:");
            int postId = int.Parse(Console.ReadLine());
            var post = DC.Posts.FirstOrDefault(p => p.Id == postId && p.UserId == loggedInUser.Id);
            if (post == null) throw new Exception("Post not found or you do not have permission to edit this post.");
            Console.WriteLine("enter new title:");
            post.Title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(post.Title)) throw new Exception("Title cannot be empty.");
            Console.WriteLine("enter new content:");
            post.Content = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(post.Content)) throw new Exception("Content cannot be empty.");
            DC.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("post edited successfully");
            Console.ResetColor();
        }
        else if (choice == "7")
        {
            Console.Clear();
            var posts = DC.Posts
                .Include(e => e.User)
                .Include(e => e.Comments)
                    .ThenInclude(c => c.User)
                .ToList();
            foreach (var post in posts)
            {
                Console.WriteLine($"post: {post}");
                Console.WriteLine($"author:{post.User}");
                if (post.Comments != null && post.Comments.Count > 0)
                {
                    Console.WriteLine("  Comments:");
                    foreach (var comment in post.Comments)
                    {
                        Console.WriteLine($"    - [{comment.Id}] {comment.Title} by {comment.User?.Username ?? "Unknown"}: {comment.Content}");
                    }
                }
                else
                {
                    Console.WriteLine("  No comments.");
                }
            }
        }
        else if (choice == "8")
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to view your posts.");
            Console.Clear();
            var posts = DC.Posts.Where(p => p.UserId == loggedInUser.Id).ToList();
            foreach (var post in posts)
            {
                Console.WriteLine(post);
            }
        }
        else if (choice == "9")
        {
            if (loggedInUser == null) throw new Exception("You must be logged in to add a comment.");
            Console.Clear();
            Console.WriteLine("enter post id to comment on:");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int postId)) throw new Exception("Invalid post id.");
            var post = DC.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) throw new Exception("Post not found.");

            var user = DC.Users.FirstOrDefault(u => u.Id == loggedInUser.Id);
            if (user == null) throw new Exception("Logged-in user not found in database.");

            Console.WriteLine("enter comment title:");
            string commentTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(commentTitle)) throw new Exception("Comment title cannot be empty.");
            Console.WriteLine("enter comment content:");
            string commentContent = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(commentContent)) throw new Exception("Comment content cannot be empty.");

            Comment comment = new Comment
            {
                Title = commentTitle,
                Content = commentContent,
                UserId = user.Id,
                PostId = post.Id,
                User = user,
                Post = post
            };

            DC.Comments.Add(comment);
            try
            {
                DC.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("comment added successfully");
                Console.ResetColor();
            }
          
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"error: {ex.Message}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("invalid choice");
            Console.ResetColor();
        }

    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"error: {ex.Message}");
        Console.ResetColor();

    }


}