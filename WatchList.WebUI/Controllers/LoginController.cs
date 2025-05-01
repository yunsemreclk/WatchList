using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.UserServices;

namespace WatchList.WebUI.Controllers
{
    public class LoginController(IUserService userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var userRole = await userService.LoginAsync(userLoginDto);
            if(userRole == "Admin")
            {
                return RedirectToAction("Index", "Movie", new {area="Admin"});

            }
            if (userRole == "User")
            {
                return RedirectToAction("Index", "Home", new { area = "User" }); 

            }
            ModelState.AddModelError("", "Email yada Şifre Hatalı.");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await userService.LogoutAsync();
            return RedirectToAction("SignIn", "Login");
        }
    }
}
