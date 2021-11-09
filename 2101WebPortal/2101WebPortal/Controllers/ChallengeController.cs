using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Vraze.Controllers
{
    public class ChallengeController : Controller
    {
        // GET: Challenge Home Page
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Index_Student");
            }
            else
            {
                return View();
            }
        }

        // GET: Challenge/Edit/{id}
        /// <summary>
        /// This methods return the view for Editing the Challenge details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/Challenge/Edit/{id}")]
        public ActionResult GotoChallengeEditPage(int id)
        {
            return View();
        }

        // GET: Create Challenge Page
        public ActionResult GotoChallengeCreatePage()
        {
            return View();
        }

        public ActionResult GotoStartChallengePage(int id)
        {
            return View("Play");
        }

        // POST: Challenge/Create
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

        // POST: ChallengeController/Edit/5
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

        // GET: ChallengeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChallengeController/Delete/5
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
