using Microsoft.AspNetCore.Identity;
using WatchList.WebUI.DTOs.UserDtos;

namespace WatchList.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);

        Task<bool> LoginAsync(UserLoginDto userLoginDto);

        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);

        Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto);
    }
}
