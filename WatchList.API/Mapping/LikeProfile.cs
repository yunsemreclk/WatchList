using AutoMapper;
using WatchList.DTO.DTOs.LikeDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<CreateLikeDto,Like>().ReverseMap();
            CreateMap<ListLikeDto,Like>().ReverseMap();
            CreateMap<UpdateLikeDto,Like>().ReverseMap();

                
            
        }
    }
}
