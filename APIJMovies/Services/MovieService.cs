using APIJMovies.DAL.Dtos;
using APIJMovies.DAL.Models;
using APIJMovies.MoviesMapper;
using APIJMovies.Repository.IRepository;
using APIJMovies.Services.IServices;
using AutoMapper;

namespace APIJMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
