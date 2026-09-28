using Inatagram.Services;

namespace Inatagram.Menu
{
    internal class PostMenu
    {
        private static PostsService _postsService = new PostsService();

        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Create post");
                Console.WriteLine("2. Delete post");
                Console.WriteLine("3. Edit post");
                Console.WriteLine("4. Get all posts");
                Console.WriteLine("5. Get post by id");
                Console.WriteLine("6. Filter posts");
                Console.WriteLine("7. Like post");
                Console.WriteLine("8. Search posts");
                Console.WriteLine("x. Exit");


                Console.Write("Enter key: ");
                string key = Console.ReadLine();


                if (key == "1")
                {
                    Console.Clear();
                    _postsService.CreatePost();
                }
                else if (key == "2")
                {
                    Console.Clear();
                    _postsService.DeletePost();
                }
                else if (key == "3")
                {
                    Console.Clear();
                    _postsService.EditPost();
                }
                else if (key == "4")
                {
                    Console.Clear();
                    _postsService.GetAllPosts();
                }
                else if (key == "5")
                {
                    Console.Clear();
                    _postsService.GetPostById();
                }
                else if (key == "6")
                {
                    Console.Clear();
                    _postsService.Filter();
                }
                else if (key == "7")
                {
                    Console.Clear();
                    _postsService.LikePost();
                }
                else if (key == "8")
                {
                    Console.Clear();
                    _postsService.Filter();
                }
                else if (key == "x")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid key.");
                }
            }
        }
    }
}
