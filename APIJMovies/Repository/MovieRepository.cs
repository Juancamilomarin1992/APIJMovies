using APIJMovies.DAL.Models;
using APIJMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace APIJMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContextMovie _dbcontex;
        public MovieRepository(ApplicationDbContextMovie dbcontext)
        {
            _dbcontex = dbcontext;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _dbcontex.Movies
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _dbcontex.Movies
                .AsNoTracking()
                .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            await _dbcontex.Movies.AddAsync(movie);
            return await SaveAsync();
        }
        
        public async Task<bool> DeleteMovieAsync(int id)
        {
           var movie =  await GetMovieAsync(id);
              if(movie == null)
              {
                return false;
            }
              _dbcontex.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<Movie> GetMovieAsync(int id) //Async and await 
        {
          return await _dbcontex.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(m=>m.Id ==id);
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _dbcontex.Movies
                .AsNoTracking()
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.UpdatedDate = DateTime.UtcNow;
           _dbcontex.Movies.Update(movie);
            return await SaveAsync();
        }
        private async Task<bool> SaveAsync()
        {
            return await _dbcontex.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
