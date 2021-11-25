using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Vraze.Models;
using Vraze.Models.WebFormDataModels;

namespace Vraze.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            var userRole = this.HttpContext.Request.Cookies["role"]; // Get the user's role stored in the cookie within the web browser

            // If the user has not logged in (no cookie found) OR the user role is not a student, redirect them to the Join Session Page
            if (string.IsNullOrEmpty(userRole) || userRole != "Student")
            {
                return RedirectToAction("JoinSession", "Student");
            }
            else // If the student has joined the session, return the dashboard with all the challenges they can play
            {
                ViewData["role"] = userRole.ToString();

                var accessCode = HttpContext.Request.Cookies["accessCode"].ToString().ToUpper();
                var session = _context.GameSessions.FirstOrDefault(session => session.AccessCode == accessCode);
                var challengeIDList = (!string.IsNullOrEmpty(session.ChallengeList)) ? session.ChallengeList.Split(';').Select(int.Parse).ToList() : new List<int>();
                List<Challenge> challengeList = null;

                if (challengeIDList.Count() > 0)
                {
                    // Grab from the database all the challenges that are added by facilitator to the current Game Session
                    challengeList = _context.Challenges.Where(challenge => challengeIDList.Contains(challenge.ChallengeId)).ToList();
                }
                else
                {
                    challengeList = new List<Challenge>(); // Empty Challenge List
                }

                ViewData["challenges"] = challengeList;
                ViewData["challengeHistory"] = _context.ChallengeHistories;
                return View("index", challengeList);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Student/Join")]
        public ActionResult JoinSession(IFormCollection collection)
        {
            return View("");
        }
    }
}
