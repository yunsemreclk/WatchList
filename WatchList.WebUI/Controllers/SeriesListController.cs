using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    public class SeriesListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
