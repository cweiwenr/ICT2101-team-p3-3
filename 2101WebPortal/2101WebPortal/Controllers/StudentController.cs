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

        [HttpGet]
        [Route("/Student/Join")]
        public IActionResult Join()
        {
            // Clear all cookies when returning back to login page to prevent unauthorised visit to other pages
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("accessCode");
            Response.Cookies.Delete("facilitatorId");
            Response.Cookies.Delete("studentId");
            Response.Cookies.Delete("accessCode");
            ViewData.Remove("role");

            return View("JoinSession");
        }

        [HttpPost]
        public IActionResult JoinSession(IFormCollection studentJoinInfo)
        {
            var session = _context.GameSessions.FirstOrDefault(g => g.AccessCode == studentJoinInfo["AccessCode"].ToString().ToUpper());

            if (session == null)
            {
                ViewData["message"] = "The game session you are trying to join does not exist.";
                return View("JoinSession");
            }

            if (session.IsActive)
            {
                var studentList = session.StudentList.Split(';').ToList();

                if (studentList.IndexOf(studentJoinInfo["StudentId"].ToString()) != -1)
                {
                    CookieOptions option = new CookieOptions();

                    option.Expires = DateTime.Now.AddMinutes(180);

                    Response.Cookies.Append("role", "Student", option);
                    Response.Cookies.Append("studentId", studentJoinInfo["StudentId"].ToString(), option);
                    Response.Cookies.Append("accessCode", session.AccessCode, option);

                    ViewData["role"] = "Student";
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewData["message"] = "You do not have access to join this session, please ask your facilitator to grant you access";
                    return View("JoinSession");
                }
            }
            else
            {
                ViewData["message"] = "The session you are trying to join has not been started by the facilitator.";
                return View("JoinSession");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Clear all cookies when returning back to home page to prevent unauthorised visit to other pages
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("accessCode");
            Response.Cookies.Delete("facilitatorId");
            Response.Cookies.Delete("studentId");
            Response.Cookies.Delete("accessCode");
            ViewData.Remove("role");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/Student/Play/{challengeId}")]
        public IActionResult Play(int challengeId)
        {
            var userRole = this.HttpContext.Request.Cookies["role"]; // Get the user's role stored in the cookie within the web browser

            // Get the challenge with the challengeId from the database
            var challenge = _context.Challenges.FirstOrDefault(challenge => challenge.ChallengeId == challengeId);

            if (challenge == null)
            {
                return RedirectToAction("Index", "Student"); //If the challenge does not exist, redirect user back to the dashboard
            }

            ViewData["role"] = userRole.ToString();

            return View("Play", challenge);
        }
    }
}
