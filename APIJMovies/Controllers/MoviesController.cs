using APIJMovies.DAL.Dtos;
using APIJMovies.Services;
using APIJMovies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIJMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsyn()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)

        {
            var movieDto = await _movieService.GetMovieAsync(id);
            return Ok(movieDto);
        }
        /*public async Task<ActionResult<ICollection<MovieDto>>> GetMovieAsync(int id)
        {
            var movies = await _movieService.GetMovieAsync(id);
            return Ok(movies);
        }  */

        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]


         public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateDto movieCreateDto)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             try
             {
                var createdMovie = await _movieService.CreateMovieAsync(movieCreateDto);

                //Vamos a retornar un 201 Created con la ruta para obtener la categoría creada
                return CreatedAtRoute(
                     "GetMovieAsync",                 //1er parámetro: nombre de la ruta
                     new { id = createdMovie.Id },    //2o parámetro: los valores de los parámetros de la ruta
                     createdMovie                     //3er parámetro: el objeto creado
                     );
             }
             catch (InvalidOperationException ex) when (ex.Message.Contains("ya existe"))
             {
                 return Conflict(new { ex.Message });
             }
             catch (Exception ex)
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
             }
         }
    }

}

