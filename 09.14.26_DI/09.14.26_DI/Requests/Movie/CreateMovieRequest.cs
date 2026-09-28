namespace _09._14._26_DI.Requests.Movie
{
    public class CreateMovieRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Director { get; set; } = null!;
        public double Rating { get; set; }
    }
}
