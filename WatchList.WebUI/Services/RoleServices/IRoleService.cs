using WatchList.WebUI.DTOs.RoleDtos;

namespace WatchList.WebUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ListRoleDto>> GetAllRolesAsync();
        Task<UpdateRoleDto> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRoleDto createRoleDto);
        Task DeleteRoleAsync(int id);


    }
}
