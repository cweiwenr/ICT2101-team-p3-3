using Microsoft.AspNetCore.Mvc;

namespace Vraze.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
