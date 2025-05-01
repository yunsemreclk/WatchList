using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class ListsController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var movieLists = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movielists");
            var seriesLists = await _client.GetFromJsonAsync<List<ListSeriesListDto>>("serieslists");
            var tierLists = await _client.GetFromJsonAsync<List<ListTierListDto>>("tierlists");

            var viewModel = new ListsPageViewModel
            {
                MovieLists = movieLists,
                SeriesLists = seriesLists,
                TierLists = tierLists
            };

            return View(viewModel);
        }
    }

    public class ListsPageViewModel
    {
        public List<ListMovieListDto> MovieLists { get; set; }
        public List<ListSeriesListDto> SeriesLists { get; set; }
        public List<ListTierListDto> TierLists { get; set; }
    }
}
