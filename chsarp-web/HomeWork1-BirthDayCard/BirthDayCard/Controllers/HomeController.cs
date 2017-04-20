using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthDayCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BirthDayMessageForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BirthDayMessageForm(Models.BirthDay birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("BirthdayCardSent", birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}