using AutoMapper;
using WatchList.DTO.DTOs.MovieListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class MovieListMapping : Profile
    {
        public MovieListMapping()
        {
            CreateMap<CreateMovieListDto, MovieList>().ReverseMap();
            CreateMap<ListMovieListDto, MovieList>().ReverseMap();
            CreateMap<UpdateMovieListDto, MovieList>().ReverseMap();
        }
    }   
    public class MovieListItemMapping : Profile
    {
        public MovieListItemMapping()
        {
            CreateMap<CreateMovieListItemDto, MovieListItem>().ReverseMap();
            CreateMap<ListMovieListItemDto, MovieListItem>().ReverseMap();
            CreateMap<UpdateMovieListItemDto, MovieListItem>().ReverseMap();
        }
    }

}
