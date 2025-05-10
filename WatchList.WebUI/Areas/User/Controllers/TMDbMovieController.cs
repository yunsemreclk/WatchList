using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.External;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class TMDbMovieController : Controller
    {
        private readonly HttpClient _client;

        public TMDbMovieController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return View();

            var response = await _client.GetFromJsonAsync<List<TMDbMovieSearchResultDto>>($"TMDbMovies/search?query={query}");
            return View(response);
        }
    }
}
