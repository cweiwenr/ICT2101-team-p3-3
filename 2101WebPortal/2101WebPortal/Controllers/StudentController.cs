using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("JoinSession");
            else
                return View();
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
