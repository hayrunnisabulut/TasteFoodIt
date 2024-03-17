using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class OpenDayHoursController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult OpenDayHoursList()
        {
            var values = context.OpenDayHours.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateOpenDayHours()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOpenDayHours(OpenDayHour openDayHour)
        {
            context.OpenDayHours.Add(openDayHour);
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");
        }

        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");

        }

        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour openDayHour)
        {
            var value = context.OpenDayHours.Find(openDayHour.OpenDayHourId);
            value.DayName = openDayHour.DayName;
            value.OpenHourRange = openDayHour.OpenHourRange;
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");
        }
    }
}