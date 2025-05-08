using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.LikeDtos;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.DTOs.UserDtos;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ExploreController : Controller
    {
        private readonly HttpClient _client;
        //private readonly UserManager<AppUser> _userManager;


        public ExploreController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
            //_userManager = userManager;
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
                .Distinct().ToList();

            //// Id → Username eşlemesi
            //var userNameDict = new Dictionary<int, string>();
            //foreach (var userId in allUserIds)
            //{
            //    var user = await _userManager.FindByIdAsync(userId.ToString());
            //    var userName = _tokenService.GetUserNameSurname; //? bak bura
            //    if (user != null)
            //    {
            //        userNameDict[userId] = user.UserName;
            //    }
            //}

            var response = await _client.PostAsJsonAsync("users/GetUserNamesById", allUserIds);
            var userList = await response.Content.ReadFromJsonAsync<List<ListUserDto>>();

            // Id → Username sözlüğü oluştur
            var userNameDict = userList.ToDictionary(u => u.Id, u => u.UserName);


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
