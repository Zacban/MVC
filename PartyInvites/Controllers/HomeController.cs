using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult Rsvpform() {
            return View();
        }

        [HttpPost]
        public ViewResult Rsvpform(GuestResponse guestresponse) {
            if (ModelState.IsValid) {
                // TODO: Email response to partyorganizer
                return View("Thanks", guestresponse);
            }
            else {
                return View();
            }
        }

        public string Alternative() {
            return "Alternative Hello World";
        }

    }
}
