using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Home
        [Route("Admin/Home")]
        public ActionResult Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToAction(nameof(LoginView));
            //else
                return View();
        }

        [Route("Admin/Login")]
        public ActionResult LoginView()
        {
            return View("Login");
        }

        // GET: Admin/Challenge/Manage/
        [Route("Admin/Challenge/Manage")]
        public ActionResult ManageChallengeView()
        {
            return View("Challenge_Admin");
        }

        // GET: Admin/Challenge/Manage/1
        [Route("Admin/Challenge/Manage/{id}")]
        public ActionResult ManageChallengeView(int id)
        {
            return View("Challenge_Admin");
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
