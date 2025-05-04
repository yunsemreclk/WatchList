using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MovieListController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;
        public MovieListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"movielists/{id}");
            return RedirectToAction("Index", "Lists");
        }

        public IActionResult Create() 
        {
            return View();  
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieListDto createMovieListDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kişi
            createMovieListDto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("movielists", createMovieListDto);
            return RedirectToAction(nameof(Index));
        }

    }
}
