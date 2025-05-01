using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.UserServices;

namespace WatchList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleAssignController(IUserService userService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await userService.GetAppUsersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            TempData["userId"] = user.Id;

            var roles = await roleManager.Roles.ToListAsync();

            var userRoles = await userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto();
                assignRole.RoleId = role.Id;
                assignRole.RoleName = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }
            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            int userId = (int)TempData["userId"];

            var user = await userService.GetUserByIdAsync(userId);

            foreach (var role in assignRoleList)
            {
                if (role.RoleExist) await userManager.AddToRoleAsync(user, role.RoleName);
                else await userManager.RemoveFromRoleAsync(user, role.RoleName);
            }

            return RedirectToAction("Index");
        }
    }
}
