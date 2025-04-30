using AutoMapper;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.RoleDtos;

namespace WatchList.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole,ListRoleDto>().ReverseMap();
            CreateMap<AppRole,CreateRoleDto>().ReverseMap();
            CreateMap<AppRole,UpdateRoleDto>().ReverseMap();
        }
    }
}
