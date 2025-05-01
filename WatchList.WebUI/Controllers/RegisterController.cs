using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Services.UserServices;

namespace WatchList.WebUI.Controllers
{
    public class RegisterController(IUserService userService) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result = await userService.CreateUserAsync(userRegisterDto);
            if (!result.Succeeded || !ModelState.IsValid)           
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }
        
    }
}
