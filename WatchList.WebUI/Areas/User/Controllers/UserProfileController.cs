using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.TokenServices;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public UserProfileController(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;

            var response = await _client.GetAsync($"users/profile/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(null); // ya da hata sayfası

            var userProfile = await response.Content.ReadFromJsonAsync<UserProfileDto>();
            return View(userProfile);
        }
    }
}
