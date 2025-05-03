using AutoMapper;
using WatchList.DTO.DTOs.TierListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class TierListProfile : Profile
    {
        public TierListProfile()
        {
            CreateMap<CreateTierListDto, TierList>().ReverseMap();
            CreateMap<ListTierListDto, TierList>().ReverseMap();
            CreateMap<UpdateTierListDto, TierList>().ReverseMap();
        }
    }

    public class TierListItemProfile : Profile
    {
        public TierListItemProfile()
        {
            // CreateMapping ile DTO ve Entity arasında dönüşüm sağlıyoruz.
            CreateMap<CreateTierListItemDto, TierListItem>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.SeriesId, opt => opt.MapFrom(src => src.SeriesId))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.MovieId.HasValue ? "Movie" : "Series"))
                .ReverseMap();

            CreateMap<ListTierListItemDto, TierListItem>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.SeriesId, opt => opt.MapFrom(src => src.SeriesId))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.MovieId.HasValue ? "Movie" : "Series"))
                .ReverseMap();

            CreateMap<UpdateTierListItemDto, TierListItem>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.SeriesId, opt => opt.MapFrom(src => src.SeriesId))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.MovieId.HasValue ? "Movie" : "Series"))
                .ReverseMap();
        }
    }

}
