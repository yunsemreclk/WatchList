using AutoMapper;
using WatchList.DTO.DTOs.SeriesListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class SeriesListProfile : Profile
    {
        public SeriesListProfile()
        {
            CreateMap<CreateSeriesListDto, SeriesList>().ReverseMap();
            CreateMap<ListSeriesListDto, SeriesList>().ReverseMap();
            CreateMap<UpdateSeriesListDto, SeriesList>().ReverseMap();
            
        }
    }

    public class SeriesListItemProfile : Profile 
    {
        public SeriesListItemProfile()
        {
            CreateMap<CreateSeriesListItemDto, SeriesListItem>().ReverseMap();
            CreateMap<ListSeriesListItemDto, SeriesListItem>().ReverseMap();
            CreateMap<UpdateSeriesListItemDto, SeriesListItem>().ReverseMap();

        }
    }
}
