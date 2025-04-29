using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.UserServices;

namespace WatchList.WebUI.Controllers
{
    public class RegisterController(IUserService userService) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDto userRegisterDto)
        {
            var result = await userService.CreateUserAsync(userRegisterDto);
            if (!result.Succeeded)           
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
        
    }
}
