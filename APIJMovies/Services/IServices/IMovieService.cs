using APIJMovies.DAL.Dtos;
using APIJMovies.DAL.Models;

namespace APIJMovies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
