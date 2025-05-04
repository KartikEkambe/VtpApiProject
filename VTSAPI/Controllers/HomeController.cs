using Microsoft.AspNetCore.Mvc;

namespace VTSAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
