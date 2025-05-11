using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.External;
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
        public async Task<IActionResult> Create(CreateSeriesDto createSeriesDto)
        {
            var userId = _tokenService.GetUserId; //kişi
            createSeriesDto.AppUserId = userId;
            await _client.PostAsJsonAsync("series", createSeriesDto);
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

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return View();

            // TMDb API'den arama sonuçlarını çekiyoruz
            var response = await _client.GetFromJsonAsync<List<TMDbSeriesSearchResultDto>>($"TMDbSeries/searchSeries?query={query}");

            // Sonuçları View'a gönderiyoruz
            return View(response);


        }


        [HttpPost]
        public async Task<IActionResult> SelectSeriesFromSearch(TMDbSeriesSearchResultDto selectedSeries)
        {
            var userId = _tokenService.GetUserId;

            // Seçilen diziyi CreateSeriesDto'ya dönüştür
            var createSeriesDto = new CreateSeriesDto
            {
                Title = selectedSeries.Title,
                PosterUrl = selectedSeries.PosterPath,
                AppUserId = userId
            };

            // Diziyi ekle
            var response = await _client.PostAsJsonAsync("series", createSeriesDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Dizi eklerken bir hata oluştu.";
            return RedirectToAction(nameof(Search));
        }
    }
}

