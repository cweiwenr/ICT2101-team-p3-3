using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Controllers
{
    public class GameSessionController : Controller
    {
        // GET: GameSessionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameSessionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameSessionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameSessionController/Create
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

        // GET: GameSessionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameSessionController/Edit/5
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

        // GET: GameSessionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameSessionController/Delete/5
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
