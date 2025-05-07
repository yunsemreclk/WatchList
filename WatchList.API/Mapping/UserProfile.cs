using AutoMapper;
using WatchList.DTO.DTOs.UserDtos;
using WatchList.Entity.Entities;

namespace WatchList.API.Mapping
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<AppUser,RegisterDto>().ReverseMap();  
        }
    }
}
