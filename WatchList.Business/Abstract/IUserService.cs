using Microsoft.AspNetCore.Identity;
using WatchList.DTO.DTOs.UserDtos;
using WatchList.Entity.Entities;

namespace WatchList.Business.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto);

        Task<string> LoginAsync(LoginDto userLoginDto);

        Task LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);

        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);

        Task<List<AppUser>> GetAllUsersAsync();

        Task<AppUser> GetUserByIdAsync(int id);

        Task<int> GetUserCount();
    }
}
