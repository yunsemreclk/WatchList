using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class LikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
