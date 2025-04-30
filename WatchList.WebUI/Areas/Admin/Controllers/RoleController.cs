using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.RoleDtos;
using WatchList.WebUI.Services.RoleServices;

namespace WatchList.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleController(IRoleService roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await roleService.GetAllRolesAsync();
            return View(values);
        }

        public IActionResult CreateRole() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await roleService.CreateRoleAsync(createRoleDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
