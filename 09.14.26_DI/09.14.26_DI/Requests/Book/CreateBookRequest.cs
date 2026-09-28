namespace _09._14._26_DI.Requests.Book
{
    public class CreateBookRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public double Price { get; set; }
    }
}
