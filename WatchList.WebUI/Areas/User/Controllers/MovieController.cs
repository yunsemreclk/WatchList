using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MovieController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + userId);
            return View(values);
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _client.DeleteAsync($"movies/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDto createMovieDto)
        {
            var userId = _tokenService.GetUserId; //kişi
            createMovieDto.AppUserId = userId;
            await _client.PostAsJsonAsync("movies", createMovieDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateMovie(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateMovieDto>($"movies/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            await _client.PutAsJsonAsync("movies", updateMovieDto);
            return RedirectToAction(nameof(Index));
        }

    }

}
