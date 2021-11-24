using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vraze.Models;

namespace Vraze.Controllers
{
    public class GameSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameSessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<GameSession> gamesessions = new List<GameSession>();
            gamesessions = _context.GameSessions.ToList();

            ViewBag.gamesessions = gamesessions;
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

        // Function to store game session details in database
        [HttpPost]
        public IActionResult AddGameSession(GameSession gamesession)
        {
            // need to check if session id already exists then reject

            _context.Add(gamesession);
            _context.SaveChanges();

            return View();
        }



    }
}
