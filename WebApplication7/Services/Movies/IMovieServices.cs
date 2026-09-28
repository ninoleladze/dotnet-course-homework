using WebApplication7.Common;
using WebApplication7.DTOs;
using WebApplication7.Models;

namespace WebApplication7.Services.Movies
{
    public interface IMovieServices
    {
        Result<int> CreateMovie(CreateMovieDto dto);
        Result<int> EditMovie(int id, EditMovieDto dto);
        Result<int> DeleteMovie(int id);
        Result<List<Movie>> GetMovies();
    }
}
