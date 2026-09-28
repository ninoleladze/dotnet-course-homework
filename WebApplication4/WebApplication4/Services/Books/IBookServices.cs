using WebApplication4.Common;
using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Books
{
    public interface IBookServices
    {
         
        ApiResponse<string> CreateBook(CreateBookDto dto);
        ApiResponse<string> EditBook(int id, UpdateBookDto dto);
        ApiResponse<string> DeleteBook(int id);
        ApiResponse<List<Book>> GetBooks();

    }
}
