using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ListsController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public ListsController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<IActionResult> Index()
        {
            var userId =  _tokenService.GetUserId;

            var movieLists = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movielists/GetMovieListByUserId/" + userId);
            var seriesLists = await _client.GetFromJsonAsync<List<ListSeriesListDto>>("serieslists/GetSeriesListByUserId/" + userId);
            var tierLists = await _client.GetFromJsonAsync<List<ListTierListDto>>("tierlists/GetTierListByUserId/" + userId);

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



