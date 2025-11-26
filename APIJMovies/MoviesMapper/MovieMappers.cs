using AutoMapper;

namespace APIJMovies.MoviesMapper
{
    public class MovieMappers : Profile
    {
        public MovieMappers() {
            CreateMap<DAL.Models.Movie, DAL.Dtos.MovieDto>().ReverseMap();
            CreateMap<DAL.Models.Movie, DAL.Dtos.MovieCreateDto>().ReverseMap();

    }
    }
}
