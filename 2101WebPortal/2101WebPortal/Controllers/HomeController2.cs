using Microsoft.AspNetCore.Mvc;

namespace Vraze.Controllers
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
