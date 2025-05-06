using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.DTOs.TierListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class TierListController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public TierListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"tierlists/{id}");
            return RedirectToAction("Index", "Lists");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTierListDto createTierListDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTierListDto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("tierlists", createTierListDto);
            return RedirectToAction("Index", "Lists");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>($"movies/GetMovieByUserId/{user.Id}");
            var series = await _client.GetFromJsonAsync<List<ListSeriesDto>>($"series/GetSeriesByUserId/{user.Id}");

            var tierList = await _client.GetFromJsonAsync<UpdateTierListDto>($"tierlists/{Id}");
            var tierListItems = await _client.GetFromJsonAsync<List<ListTierListItemDto>>("tierlistitem/GetTierListItemByTierListId/" + tierList.Id);

            var viewModel = new TierListPageViewModel
            {
                Series = series,

                Movies = movies,
                TierList = tierList,
                TierListItem = new CreateTierListItemDto { TierListId = Id },
                ListTierListItem = tierListItems,
                Tier = new() { "S", "A", "B", "C", "D", "F" },
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateTierListItemDto createTierListItemDto)
        {
            var existingItems = await _client.GetFromJsonAsync<List<ListTierListItemDto>>(
                $"tierlistitem/GetTierListItemByTierListId/{createTierListItemDto.TierListId}");

            bool exists = false;
            if (createTierListItemDto.ItemType == "Movie")
                exists = existingItems.Any(x => x.MovieId == createTierListItemDto.MovieId);
            else if (createTierListItemDto.ItemType == "Series")
                exists = existingItems.Any(x => x.SeriesId == createTierListItemDto.SeriesId);

            if (exists)
            {
                TempData["ErrorMessage"] = "Bu içerik zaten tier listede mevcut.";
                return RedirectToAction(nameof(Edit), new { id = createTierListItemDto.TierListId });
            }

            await _client.PostAsJsonAsync("tierlistitem", createTierListItemDto);
            return RedirectToAction(nameof(Edit), new { id = createTierListItemDto.TierListId});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id, int tierListId)
        {
            await _client.DeleteAsync($"tierlistitem/{id}");
            return RedirectToAction("Edit", new { id = tierListId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>($"movies/GetMovieByUserId/{user.Id}");
            var series = await _client.GetFromJsonAsync<List<ListSeriesDto>>($"series/GetSeriesByUserId/{user.Id}");
            var tierList = await _client.GetFromJsonAsync<UpdateTierListDto>($"tierlists/{id}");
            var tierItems = await _client.GetFromJsonAsync<List<ListTierListItemDto>>($"tierlistitem/GetTierListItemByTierListId/{tierList.Id}");

            var viewModel = new TierListPageViewModel
            {
                TierList = tierList,
                ListTierListItem = tierItems,
                Movies = movies,
                Series = series,
                Tier = new() { "S", "A", "B", "C", "D", "F" }
            };

            return View(viewModel);
        }
    }

    public class TierListPageViewModel
    {
        public ListMovieDto Movie { get; set; }
        public List<ListMovieDto> Movies { get; set; }
        public ListSeriesDto Serie { get; set; }
        public List<ListSeriesDto> Series { get; set; }
        public UpdateTierListDto TierList { get; set; }
        public CreateTierListItemDto TierListItem { get; set; }
        public List<ListTierListItemDto> ListTierListItem { get; set; }
        public List<string> Tier { get; set; } = new();
    }

}
