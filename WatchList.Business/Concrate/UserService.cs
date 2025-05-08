using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchList.Business.Abstract;
using WatchList.DataAccess.Context;
using WatchList.DTO.DTOs.UserDtos;
using WatchList.Entity.Entities;

namespace WatchList.Business.Concrate
{
    public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper _mapper, WatchListContext _context) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto)
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

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<int> GetUserCount()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            return users.Count();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(LoginDto userLoginDto)
        {
            var user = await userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return null;
            }
            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false); //sürekli açık kalsın mı false
            if (!result.Succeeded)
            {
                return null;
            }
            else
            {
                var IsAdmin = await userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) return "Admin";
                var IsUser = await userManager.IsInRoleAsync(user, "User");
                if (IsUser) return "User";
            }
            return null;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
