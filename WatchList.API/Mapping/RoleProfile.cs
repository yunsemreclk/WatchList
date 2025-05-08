using AutoMapper;
using WatchList.DTO.DTOs.RoleDtos;
using WatchList.Entity.Entities;

namespace WatchList.API.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
        }
    }
}
