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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movies/GetMovieListByUserId/" + user.Id);
            return View(values);
        }
    }
}
