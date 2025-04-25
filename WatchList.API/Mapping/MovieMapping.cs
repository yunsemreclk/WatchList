using AutoMapper;
using WatchList.DTO.DTOs.MovieDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class MovieMapping : Profile
    {
        public MovieMapping() 
        {
            CreateMap<CreateMovieDto, Movie>().ReverseMap();
            CreateMap<ListMovieDto, Movie>().ReverseMap();
            CreateMap<UpdateMovieDto, Movie>().ReverseMap();
        }
    }
}
