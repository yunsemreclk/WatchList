using Microsoft.AspNetCore.Identity;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.UserDtos;

namespace WatchList.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : IUserService
    {
        public Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto)
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
            return await userManager.CreateAsync(user, userRegisterDto.Password);

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

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
