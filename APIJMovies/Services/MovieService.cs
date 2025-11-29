using APIJMovies.DAL.Dtos;
using APIJMovies.DAL.Models;
using APIJMovies.MoviesMapper;
using APIJMovies.Repository;
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

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            //validar si la categoria existe
            // validar si la categoria ya existe
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de {movieCreateDto.Name}");
            }
            // mapear el Dto de la entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);
            // crear la categoria en el repositorio
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("ocurrio un error al crear la categoria");
            }
            //Mapear la entidad creada a Dto
            return _mapper.Map<MovieDto>(movie);
        } ///final CreateCategoryAsync

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
