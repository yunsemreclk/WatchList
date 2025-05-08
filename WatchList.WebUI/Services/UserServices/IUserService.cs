using Microsoft.AspNetCore.Identity;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Models;

namespace WatchList.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);

        Task<string> LoginAsync(UserLoginDto userLoginDto);

        Task LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);

        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);

        Task<List<UserViewModel>> GetAllUsersAsync();

        Task<List<AssignRoleDto>> GetUserForRoleAssign(int id);

        Task<int> GetUserCount();
    }
}
