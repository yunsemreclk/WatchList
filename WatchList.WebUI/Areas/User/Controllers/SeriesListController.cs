using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.SeriesDtos;
using WatchList.WebUI.DTOs.SeriesListDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class SeriesListController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        public SeriesListController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
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
            var userId = _tokenService.GetUserId;
            createSeriesListDto.AppUserId = userId;
            await _client.PostAsJsonAsync("serieslists", createSeriesListDto);
            return RedirectToAction("Index","Lists");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var userId = _tokenService.GetUserId;
            var series = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series/GetSeriesByUserId/" + userId);
            var seriesList = await _client.GetFromJsonAsync<UpdateSeriesListDto>($"serieslists/{Id}");
            var seriesListItem = await _client.GetFromJsonAsync<List<ListSeriesListItemDto>>("serieslistitem/GetSeriesListItemBySeriesListId/" + seriesList.Id);

            var viewModel = new SeriesListPageViewModel
            {
                Series = series,
                SeriesList = seriesList,
                SeriesListItem = new CreateSeriesListItemDto { SeriesListId = Id },
                ListSeriesListItem = seriesListItem
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateSeriesListItemDto createSeriesListItemDto)
        {
            // Listeye ait mevcut item'ları çek
            var existingItems = await _client.GetFromJsonAsync<List<ListSeriesListItemDto>>(
                "serieslistitem/GetSeriesListItemBySeriesListId/" + createSeriesListItemDto.SeriesListId);

            // Aynı film zaten var mı?
            var isExists = existingItems.Any(x => x.SeriesId == createSeriesListItemDto.SeriesId);
            if (isExists)
            {
                TempData["ErrorMessage"] = "Bu film zaten listede var.";
                return RedirectToAction(nameof(Edit), new { id = createSeriesListItemDto.SeriesListId });
            }

            // Eklemeye devam
            await _client.PostAsJsonAsync("serieslistitem", createSeriesListItemDto);
            return RedirectToAction(nameof(Edit), new { id = createSeriesListItemDto.SeriesListId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id, int seriesListId)
        {
            await _client.DeleteAsync($"serieslistitem/{id}");
            return RedirectToAction("Edit", "SeriesList", new { id = seriesListId });
        }

        public async Task<IActionResult> Details(int Id)
        {
            var userId = _tokenService.GetUserId;

            var series = await _client.GetFromJsonAsync<List<ListSeriesDto>>("series/GetSeriesByUserId/" + userId);
            var seriesList = await _client.GetFromJsonAsync<UpdateSeriesListDto>($"serieslists/{Id}");
            var seriesListItem = await _client.GetFromJsonAsync<List<ListSeriesListItemDto>>("serieslistitem/GetSeriesListItemBySeriesListId/" + seriesList.Id);

            var viewModel = new SeriesListPageViewModel
            {
                Series = series,
                SeriesList = seriesList,
                SeriesListItem = null, // Form olmayacak, sadece görüntüleme
                ListSeriesListItem = seriesListItem
            };
            return View(viewModel);
        }
    }

    public class SeriesListPageViewModel
    {
        public ListSeriesDto Serie { get; set; }
        public List<ListSeriesDto> Series { get; set; }
        public UpdateSeriesListDto SeriesList { get; set; }
        public CreateSeriesListItemDto SeriesListItem { get; set; }
        public List<ListSeriesListItemDto> ListSeriesListItem { get; set; }
    }
}
