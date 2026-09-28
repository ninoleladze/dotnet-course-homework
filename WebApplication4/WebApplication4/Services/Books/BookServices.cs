using WebApplication4.Common;
using WebApplication4.Data;
using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Books
{
    public class BookServices : IBookServices
    {
        private DataContext _db;

        public BookServices(DataContext db) => _db = db;

        public ApiResponse<string> CreateBook(CreateBookDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return new ApiResponse<string> { Status = 400, Message = "Title is required." };

            if (string.IsNullOrWhiteSpace(dto.Author))
                return new ApiResponse<string> { Status = 400, Message = "Author is required." };

            if (dto.Price <= 0)
                return new ApiResponse<string> { Status = 400, Message = "Price must be greater than zero." };

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                Price = dto.Price
            };

            _db.Books.Add(book);
            _db.SaveChanges();

            return new ApiResponse<string> { Status = 200, Message = "Book created successfully." };
        }

        public ApiResponse<string> EditBook(int id, UpdateBookDto dto)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return new ApiResponse<string> { Status = 404, Message = "Book not found." };

            if (!string.IsNullOrWhiteSpace(dto.Title))
                book.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Author))
                book.Author = dto.Author;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                book.Description = dto.Description;

            if (dto.Price > 0)
                book.Price = dto.Price;

            _db.SaveChanges();

            return new ApiResponse<string> { Status = 200, Message = "Book updated successfully." };
        }
        public ApiResponse<string> DeleteBook(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return new ApiResponse<string> { Status = 404, Message = "Book not found." };

            _db.Books.Remove(book);
            _db.SaveChanges();

            return new ApiResponse<string> { Status = 200, Message = "Book deleted successfully." };
        }

        public ApiResponse<List<Book>> GetBooks()
        {
            var books = _db.Books.ToList();
            return new ApiResponse<List<Book>>
            {
                Status = 200,
                Value = books,
                Message = "Books retrieved successfully."
            };
        }
    }


}
