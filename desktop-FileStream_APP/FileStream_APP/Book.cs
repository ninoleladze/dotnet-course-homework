namespace FileStream_APP
{
    public class Book
    {
        private static int _counter = 1;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book() => Id = _counter++;

        public override string ToString()
        {
            return $"ID: {Id}, title: {Title}, author: {Author}, year: {Year}";
        }
    }
}
