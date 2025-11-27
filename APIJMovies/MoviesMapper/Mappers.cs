using APIJMovies.DAL.Models;
using APIJMovies.DAL.Dtos;
using AutoMapper;


namespace APIJMovies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUdateDto>().ReverseMap();

        }
    }
}
