using AutoMapper;
using WatchList.DTO.DTOs.LikeDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Mapping
{
    public class LikeMapping : Profile
    {
        public LikeMapping()
        {
            CreateMap<CreateLikeDto,Like>().ReverseMap();
            CreateMap<ListLikeDto,Like>().ReverseMap();
            CreateMap<UpdateLikeDto,Like>().ReverseMap();

                
            
        }
    }
}
