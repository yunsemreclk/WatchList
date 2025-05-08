using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.RoleDtos;

namespace WatchList.WebUI.Areas.Admin.Controllers
{

    [Authorize(Roles = "User")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly HttpClient _client;

        public RoleController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ListRoleDto>>("roles");
            return View(values);
        }

        public IActionResult CreateRole() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await _client.PostAsJsonAsync("roles",createRoleDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _client.DeleteAsync("roles/" + id);
            return RedirectToAction("Index");
        }
    }
}
