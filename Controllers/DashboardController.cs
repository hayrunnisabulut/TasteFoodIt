using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x => x.ReservationStatus == "Onaylandı").Count();
            ViewBag.v5 = context.Reservations.Where(x => x.ReservationStatus == "Beklemede").Count();
            ViewBag.v6 = context.Reservations.Where(x => x.ReservationStatus == "Reddedildi").Count();
            ViewBag.v7 = context.Reservations.Count();
            return View();
        }
        public PartialViewResult Reservations()
        {
            var values = context.Reservations.Where(x => x.ReservationStatus != "Reddedildi").ToList();
            return PartialView(values);
        }
        public PartialViewResult Messages()
        {
            var values = context.Contacts.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }

    }
}