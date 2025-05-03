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

            var values = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movielists/GetMovieListByUserId/" + user.Id);
            return View(values);


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
