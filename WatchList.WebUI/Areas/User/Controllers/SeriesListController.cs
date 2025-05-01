using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WatchList.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class SeriesListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
