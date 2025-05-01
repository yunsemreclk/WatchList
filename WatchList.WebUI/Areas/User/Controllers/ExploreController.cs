using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Areas.User.Controllers
{
    public class ExploreController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
