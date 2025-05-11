using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.External;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MovieController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies/GetMovieByUserId/" + userId);
            return View(values);
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _client.DeleteAsync($"movies/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            if (TempData["FromTMDb"] is string json)
            {
                var movie = System.Text.Json.JsonSerializer.Deserialize<CreateMovieDto>(json);
                return View(movie);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDto createMovieDto)
        {
            var userId = _tokenService.GetUserId; //kişi
            createMovieDto.AppUserId = userId;
            await _client.PostAsJsonAsync("movies", createMovieDto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateMovie(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateMovieDto>($"movies/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            await _client.PutAsJsonAsync("movies", updateMovieDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return View();

            var response = await _client.GetFromJsonAsync<List<TMDbMovieSearchResultDto>>($"TMDbMovies/search?query={query}");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SelectMovieFromSearch(TMDbMovieSearchResultDto selectedMovie)
        {
            // Kullanıcı ID'sini al
            var userId = _tokenService.GetUserId;

            // ReleaseDate'i int (Yıl) olarak al Sonradan düzenlenecek
            int releaseYear = 0;
            if (int.TryParse(selectedMovie.ReleaseDate.Substring(0, 4), out releaseYear))
            {
                // Yıl başarılı şekilde alındı
            }
            else
            {
                // Eğer yıl alınamazsa, hata mesajı gösterilebilir
                TempData["ErrorMessage"] = "Geçersiz yayın tarihi.";
                return RedirectToAction(nameof(Search));
            }

            // Seçilen filmi CreateMovieDto'ya dönüştür
            var createMovieDto = new CreateMovieDto
            {
                Title = selectedMovie.Title,
                PosterUrl = selectedMovie.PosterPath,
                ReleaseYear = releaseYear, // Yılı alıyoruz
                AppUserId = userId // Kullanıcı ID'sini ekle
            };

            // Filmi ekle
            var response = await _client.PostAsJsonAsync("movies", createMovieDto);

            // Eğer film başarıyla eklendiyse, kullanıcıyı ana sayfaya yönlendir
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            // Başarısız olursa hata mesajı göster
            TempData["ErrorMessage"] = "Filmi eklerken bir hata oluştu.";
            return RedirectToAction(nameof(Search));
        }



    }

}
