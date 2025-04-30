using Microsoft.AspNetCore.Identity;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.UserDtos;

namespace WatchList.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);

        Task<string> LoginAsync(UserLoginDto userLoginDto);

        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);

        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);

        Task<List<AppUser>> GetAppUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
    }
}
