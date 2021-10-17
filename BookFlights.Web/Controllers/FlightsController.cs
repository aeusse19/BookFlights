using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookFlights.Web.Controllers
{
    public class FlightsController : Controller
    {
        // GET: Flights
        public ActionResult Index()
        {
            return View();
        }
    }
}