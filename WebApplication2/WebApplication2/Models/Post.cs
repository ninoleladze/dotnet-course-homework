namespace WebApplication2.Models
{
    public class Post
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string Author { get; set; }

        public Post(string title, string desc, string author) {
            Id = _id++;
            Title = title;
            Describtion = desc;
            Author = author;
        }

    }
}
