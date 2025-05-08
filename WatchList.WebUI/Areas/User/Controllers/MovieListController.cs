using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.Services.TokenServices;


namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MovieListController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MovieListController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"movielists/{id}");
            return RedirectToAction("Index", "Lists");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieListDto createMovieListDto)
        {
            var userId = _tokenService.GetUserId;
            createMovieListDto.AppUserId = userId;
            await _client.PostAsJsonAsync("movielists", createMovieListDto);
            return RedirectToAction("Index", "Lists");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var userId = _tokenService.GetUserId;
            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + userId);
            var movieList = await _client.GetFromJsonAsync<UpdateMovieListDto>($"movielists/{Id}");
            var movieListItem = await _client.GetFromJsonAsync<List<ListMovieListItemDto>>("movielistitem/GetMovieListItemByMovieListId/" + movieList.Id);


            //GetMovieListItemByMovieListId
            var viewModel = new MovieListPageViewModel
            {
                Movies = movies,
                MovieList = movieList,
                MovieListItem = new CreateMovieListItemDto { MovieListId = Id },
                ListMovieListItem = movieListItem
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateMovieListItemDto createMovieListItemDto)
        {
            // Listeye ait mevcut item'ları çek
            var existingItems = await _client.GetFromJsonAsync<List<ListMovieListItemDto>>(
                "movielistitem/GetMovieListItemByMovieListId/" + createMovieListItemDto.MovieListId);

            // Aynı film zaten var mı?
            var isExists = existingItems.Any(x => x.MovieId == createMovieListItemDto.MovieId);
            if (isExists)
            {
                TempData["ErrorMessage"] = "Bu film zaten listede var.";
                return RedirectToAction(nameof(Edit), new { id = createMovieListItemDto.MovieListId });
            }

            // Eklemeye devam
            await _client.PostAsJsonAsync("movielistitem", createMovieListItemDto);
            return RedirectToAction(nameof(Edit), new { id = createMovieListItemDto.MovieListId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id, int movieListId)
        {
            await _client.DeleteAsync($"movielistitem/{id}");
            return RedirectToAction("Edit", "MovieList", new { id = movieListId });
        }

        public async Task<IActionResult> Details(int Id)
        {
            var userId = _tokenService.GetUserId;

            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + userId);
            var movieList = await _client.GetFromJsonAsync<UpdateMovieListDto>($"movielists/{Id}");
            var movieListItem = await _client.GetFromJsonAsync<List<ListMovieListItemDto>>("movielistitem/GetMovieListItemByMovieListId/" + movieList.Id);

            var viewModel = new MovieListPageViewModel
            {
                Movies = movies,
                MovieList = movieList,
                MovieListItem = null, // Form olmayacak, sadece görüntüleme
                ListMovieListItem = movieListItem
            };
            return View(viewModel);
        }
    }

    public class MovieListPageViewModel
    {
        public ListMovieDto Movie { get; set; }
        public List<ListMovieDto> Movies { get; set; }
        public UpdateMovieListDto MovieList { get; set; }
        public CreateMovieListItemDto MovieListItem { get; set; }
        public List<ListMovieListItemDto> ListMovieListItem { get; set; }
    }
}

