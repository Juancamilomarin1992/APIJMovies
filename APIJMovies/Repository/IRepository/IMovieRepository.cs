using APIJMovies.DAL.Models;

namespace APIJMovies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();//Me retorna una lista de Movies
        Task<Movie> GetMovieAsync(int id);//Me retorna una Movie por id
        Task<bool> CreateMovieAsync(Movie movie);//crea una nueva Movie
        Task<bool> UpdateMovieAsync(Movie movie);//Me actualiza una Movie
        Task<bool> DeleteMovieAsync(int id);//Me elimina una Movie
        Task<bool> MovieExistsByNameAsync(string name);


    }
}
