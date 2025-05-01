using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.UserDtos;

namespace WatchList.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email
            };
            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword) 
            {
                return new IdentityResult();
            }
            var result = await userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded) 
            {
                await userManager.AddToRoleAsync(user, "User");
                return result;
            }
            return result;

        }

        public async Task<List<AppUser>> GetAppUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await userManager.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) 
            {
                return null;
            }
            var result = await signInManager.PasswordSignInAsync(user,userLoginDto.Password,false,false); //sürekli açık kalsın mı false
            if (!result.Succeeded) return null;
            else 
            {
                var IsAdmin = await userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) return "Admin";
                var IsUser = await userManager.IsInRoleAsync(user, "User");
                if (IsUser) return "User";
            }

            return null;


            
        }

        public async Task<bool> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return true;
        }
    }
}
