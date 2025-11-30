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

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //validar si la categoria existe
            
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
        }
        public Task<bool> CreateUdateMovieAsync(MovieCreateUpdateDto dto)
        
        {
            throw new NotImplementedException();
        }

        ///final CreateCategoryAsync

        public async Task<bool> DeleteMovieAsync(int id)
        {
           //validar si la pelicula exite
           var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"no se encontro la pelicula con ID: {id}");
            }
            //eliminar la pelicula del repositorio
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (!movieDeleted)
            {
                throw new Exception("ocurrio un error al eliminar la pelicula");
            }
            return movieDeleted;
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            //obtener la categoria por id desde el repositorio
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"no se encontro la pelicula con Id: {id}");
            }
            //Mapear toda coleccion de una vez
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            //validar si la categoria existe
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists==null)
            {
                throw new InvalidOperationException($"no se encontro la pelicula con ID: {id}");
            }
            var nameExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de: {dto.Name}");
            }
            // mapear el Dto de la entidad
            _mapper.Map(dto, movieExists);

            // actualizar la categoria en el repositorio
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("ocurrio un error al actualizar la pelicula");
            }

            return _mapper.Map<MovieDto>(movieExists);
        }

        Task<bool> IMovieService.UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
