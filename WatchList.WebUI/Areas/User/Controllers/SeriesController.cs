using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class SeriesController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series");
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
