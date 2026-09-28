namespace WebApplication2.Models
{
    public class Book
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
            public string Author { get; set; }
    
            public Book(int id, string title, string description, string author)
            {
                Id = _id++;
                Title = title;
                Description = description;
                Author = author;
        }

    }
}
