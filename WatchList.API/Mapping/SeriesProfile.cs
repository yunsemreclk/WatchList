using AutoMapper;
using WatchList.DTO.DTOs.SeriesDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class SeriesProfile : Profile
    {
        public SeriesProfile()
        {
            CreateMap<CreateSeriesDto, Series>().ReverseMap();
            CreateMap<ListSeriesDto, Series>().ReverseMap();
            CreateMap<UpdateSeriesDto, Series>().ReverseMap();
            
        }
    }
}
