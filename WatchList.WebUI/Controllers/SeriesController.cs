using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
