using BooksApp.Models;
using BooksApp.Repositories;

namespace BooksApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository(IEnumerable<Book>? initialBooks = null)
        {
            _books = initialBooks?.ToList() ?? new List<Book>();
        }

        public void Add(Book book) => _books.Add(book);

        public Book? GetBookById(Guid id) =>
            _books.FirstOrDefault(b => b.Id == id);

        public IEnumerable<Book> FilterByTitle(string titleFragment) =>
            string.IsNullOrWhiteSpace(titleFragment)
                ? Enumerable.Empty<Book>()
                : _books.Where(b => b.Title.Contains(titleFragment, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Book> FilterByAuthor(string authorFragment) =>
            string.IsNullOrWhiteSpace(authorFragment)
                ? Enumerable.Empty<Book>()
                : _books.Where(b => b.Author.Contains(authorFragment, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Book> FilterByCreatedAt(DateTime from, DateTime to) =>
            _books.Where(b => b.CreatedAt >= from && b.CreatedAt <= to);

        public IEnumerable<Book> FilterByCreatedAt(DateTime date) =>
            _books.Where(b => b.CreatedAt.Date == date.Date);

        public IEnumerable<Book> SearchByTitleOrAuthor(string query) =>
            string.IsNullOrWhiteSpace(query)
                ? Enumerable.Empty<Book>()
                : _books.Where(b =>
                    b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(query, StringComparison.OrdinalIgnoreCase));

        public Book? SearchFirstByTitleOrAuthor(string query) =>
            string.IsNullOrWhiteSpace(query)
                ? null
                : _books.FirstOrDefault(b =>
                    b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}