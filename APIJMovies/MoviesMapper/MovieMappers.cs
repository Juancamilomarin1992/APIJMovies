using APIJMovies.DAL.Dtos;
using APIJMovies.DAL.Models;
using AutoMapper;

namespace APIJMovies.MoviesMapper
{
    public class MovieMappers : Profile
    {
        public MovieMappers() {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();

    }
    }
}
