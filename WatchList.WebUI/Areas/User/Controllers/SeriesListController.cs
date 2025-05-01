using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class SeriesListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
