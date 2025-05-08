using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class SeriesController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public SeriesController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series/GetSeriesByUserId/" + userId);
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
            var userId = _tokenService.GetUserId; //kişi
            createMovieDto.AppUserId = userId;
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
