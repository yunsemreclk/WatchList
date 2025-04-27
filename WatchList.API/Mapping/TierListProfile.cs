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
            CreateMap<CreateTierListItemDto, TierListItem>().ReverseMap();
            CreateMap<ListTierListItemDto, TierListItem>().ReverseMap();
            CreateMap<UpdateTierListItemDto, TierListItem>().ReverseMap();
        }
    }
}
