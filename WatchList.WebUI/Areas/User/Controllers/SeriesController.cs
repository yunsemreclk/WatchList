using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class SeriesController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public SeriesController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series/GetSeriesByUserId/" + user.Id);
            return View(values);
        }




        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _client.DeleteAsync($"series/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeriesDto createMovieDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kişi
            createMovieDto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("series", createMovieDto);
            return RedirectToAction(nameof(Index));         
         
        }

        public async Task<IActionResult> UpdateSeries(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSeriesDto>($"series/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesDto updateMovieDto)
        {
            await _client.PutAsJsonAsync("series", updateMovieDto); 
            return RedirectToAction(nameof(Index));
        }
    }
}
