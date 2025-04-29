using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Controllers
{
    public class TierListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
