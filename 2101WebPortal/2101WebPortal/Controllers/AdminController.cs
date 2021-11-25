using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vraze.Models;

namespace Vraze.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Admin/Home")]
        public ActionResult Index()
        {
            var roleCookie = this.HttpContext.Request.Cookies["role"]; //Get the role of the user from the request's cookie

            //If the user has not logged in (no cookie found) or if the user is not privilleged, return them to the Admin's login page.
            if (string.IsNullOrEmpty(roleCookie) && (roleCookie != "Admin" || roleCookie != "Facilitator"))
            {
                return View("Login");
            }
            else //If the user is privilleged, redirect the user to the Admin's dashboard.
            {
                ViewData["role"] = roleCookie.ToString();
                return View("Index");
            }
        }

        [Route("Admin/Login")]
        [HttpGet]
        public ActionResult Login()
        {
            // Clear all cookies when returning back to login page to prevent unauthorised visit to other pages
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("accessCode");
            Response.Cookies.Delete("facilitatorId");
            Response.Cookies.Delete("studentId");
            Response.Cookies.Delete("accessCode");
            ViewData.Remove("role");

            return View("Login");
        }

        [Route("Admin/Login")]
        [HttpPost]
        public IActionResult Login([Bind("Username", "PasswordHash")]Facilitator model)
        {
            // Clear all cookies when returning back to login page to prevent unauthorised visit to other pages
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("accessCode");
            Response.Cookies.Delete("facilitatorId");
            Response.Cookies.Delete("studentId");
            Response.Cookies.Delete("accessCode");
            ViewData.Remove("role");

            var user = _context.Facilitators.Where(f => f.Username == model.Username).FirstOrDefault();

            if (user == null)
            {
                ViewData["message"] = "You have entered an invalid username/password. Please try again.";
                return View("Login");
            }

            if (BCrypt.Net.BCrypt.Verify(model.PasswordHash, user.PasswordHash))
            {
                CookieOptions option = new CookieOptions();

                option.Expires = DateTime.Now.AddMinutes(180);

                Response.Cookies.Append("role", (user.IsSystemAdmin) ? "Admin" : "Facilitator", option);
                Response.Cookies.Append("facilitatorId", user.Id.ToString(), option);

                ViewData["role"] = (user.IsSystemAdmin) ? "Admin" : "Facilitator";

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewData["message"] = "You have entered an invalid username/password. Please try again.";
                return View("Login");
            }
        }

        [Route("Admin/Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            // Clear all cookies when returning back to login page to prevent unauthorised visit to other pages
            Response.Cookies.Delete("role");
            Response.Cookies.Delete("accessCode");
            Response.Cookies.Delete("facilitatorId");
            Response.Cookies.Delete("studentId");
            Response.Cookies.Delete("accessCode");
            ViewData.Remove("role");

            return RedirectToAction("Index", "Home");
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
