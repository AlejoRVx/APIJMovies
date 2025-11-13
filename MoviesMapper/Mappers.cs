using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;
using AutoMapper;

namespace API.J.Movies.MoviesMapper
{
    public class Mappers: Profile
    {
        public Mappers()
        {
            //Category Mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
