using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    [Area("User")]
    public class TierListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
