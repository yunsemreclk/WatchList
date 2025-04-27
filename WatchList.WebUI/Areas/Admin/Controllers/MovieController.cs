using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies");
            return View(values);
        }
    }
}
