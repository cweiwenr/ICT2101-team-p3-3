using Microsoft.AspNetCore.Mvc;

namespace Vraze.Controllers
{
    public class GameSessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("GameSession/createSession")]
        public ActionResult CreateSession()
        {
            return View("CreateSession");
        }
    }
}
