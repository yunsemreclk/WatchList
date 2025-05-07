using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        } 
        public IActionResult AccessDenied403()
        {
            return View();
        }
    }
}
