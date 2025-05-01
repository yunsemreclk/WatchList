using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class MovieListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
