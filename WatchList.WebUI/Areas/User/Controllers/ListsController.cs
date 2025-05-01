using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ListsController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public ListsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var movieLists = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movielists/GetMovieListByUserId/" + user.Id);
            var seriesLists = await _client.GetFromJsonAsync<List<ListSeriesListDto>>("serieslists/GetSeriesListByUserId/" + user.Id);
            var tierLists = await _client.GetFromJsonAsync<List<ListTierListDto>>("tierlists/GetTierListByUserId/" + user.Id);

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



