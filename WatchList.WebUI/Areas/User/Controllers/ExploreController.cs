using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.LikeDtos;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ExploreController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public ExploreController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var movieLists = await _client.GetFromJsonAsync<List<ListMovieListDto>>("movielists/GetSharedMovieList");
            var seriesLists = await _client.GetFromJsonAsync<List<ListSeriesListDto>>("serieslists/GetSharedSeriesList");
            var tierLists = await _client.GetFromJsonAsync<List<ListTierListDto>>("tierlists/GetSharedTierList");

            // Tüm AppUserId'leri topla (tekrarsız)
            var allUserIds = movieLists.Select(x => x.AppUserId)
                .Concat(seriesLists.Select(x => x.AppUserId))
                .Concat(tierLists.Select(x => x.AppUserId))
                .Distinct();

            // Id → Username eşlemesi
            var userNameDict = new Dictionary<int, string>();
            foreach (var userId in allUserIds)
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user != null)
                {
                    userNameDict[userId] = user.UserName;
                }
            }


            var viewModel = new ExplorePageViewModel
            {
                MovieLists = movieLists,
                SeriesLists = seriesLists,
                TierLists = tierLists,
                UserNameDictionary = userNameDict
            };

            return View(viewModel);
        }
    }

    public class ExplorePageViewModel
    {
        public List<ListMovieListDto> MovieLists { get; set; }
        public List<ListSeriesListDto> SeriesLists { get; set; }
        public List<ListTierListDto> TierLists { get; set; }
        public List<ListLikeDto> LikeLists { get; set; }

        public Dictionary<int, string> UserNameDictionary { get; set; } = new();



    }
}
