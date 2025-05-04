using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Entity.Entites;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class SeriesListController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;
        public SeriesListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"serieslists/{id}");
            return RedirectToAction("Index", "Lists");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateSeriesListDto createSeriesListDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kişi
            createSeriesListDto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("serieslists", createSeriesListDto);
            return RedirectToAction("Index","Lists");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var series = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series/GetSeriesByUserId/" + user.Id);
            var seriesList = await _client.GetFromJsonAsync<UpdateSeriesListDto>($"serieslists/{Id}");

            var viewModel = new SeriesListPageViewModel
            {
                Series = series,
                SeriesList = seriesList,
                SeriesListItem = new CreateSeriesListItemDto { SeriesListId = Id }
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateSeriesListItemDto createSeriesListItemDto)
        {
            await _client.PostAsJsonAsync("serieslistitem", createSeriesListItemDto);
            return RedirectToAction(nameof(Edit), new { listId = createSeriesListItemDto.SeriesListId });
        }
    }

    public class SeriesListPageViewModel
    {
        public List<ListSeriesDto> Series { get; set; }
        public UpdateSeriesListDto SeriesList { get; set; }
        public CreateSeriesListItemDto SeriesListItem { get; set; }
    }
}
