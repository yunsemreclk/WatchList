using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    public class MovieListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
