using AutoMapper;
using WatchList.DTO.DTOs.RoleDtos;
using WatchList.DTO.DTOs.UserDtos;
using WatchList.Entity.Entities;

namespace WatchList.API.Mapping
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<AppUser,RegisterDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
            CreateMap<AppUser, ListUserDto>().ReverseMap();
            CreateMap<AppUser, UserProfileDto>().ReverseMap();
            
        }
    }
}
