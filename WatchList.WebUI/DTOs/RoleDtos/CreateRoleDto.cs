using AutoMapper;

namespace WatchList.WebUI.DTOs.RoleDtos
{
    public class CreateRoleDto : Profile
    {
        public string Name { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
