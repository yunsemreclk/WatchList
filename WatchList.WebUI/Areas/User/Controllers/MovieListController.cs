using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WatchList.Entity.Entites;
using WatchList.Entity.Entities;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.DTOs.MovieListDtos;
using WatchList.WebUI.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MovieListController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;
        public MovieListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kişi
            createMovieListDto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("movielists", createMovieListDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + user.Id);
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var movies = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + user.Id);
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

