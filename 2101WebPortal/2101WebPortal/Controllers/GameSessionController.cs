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

        [Route("GameSession/RemoveSession")]
        public ActionResult RemoveSession()
        {
            return View("RemoveSession");
        }

        [Route("GameSession/ModifySession")]
        public ActionResult ModifySession()
        {
            return View("ModifySession");
        }

        [Route("GameSession/StartEndSession")]
        public ActionResult StartEndSession()
        {
            return View("StartEndSession");
        }
        //have to do the create functions to store session details into database
    }
}
