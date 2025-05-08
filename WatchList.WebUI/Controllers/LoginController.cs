using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.UserServices;
using WatchList.WebUI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using WatchList.WebUI.DTOs.LoginDtos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WatchList.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;
        public LoginController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var result = await _client.PostAsJsonAsync("users/login", userLoginDto);
            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(userLoginDto);
            }
            var handler = new JwtSecurityTokenHandler();
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDto>();
            var token = handler.ReadJwtToken(response.Token);
            var claims= token.Claims.ToList();

            if(response.Token != null)
            {
                claims.Add(new Claim("Token", response.Token));  
                var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            return View(userLoginDto);

        }
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
