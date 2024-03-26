using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult Index()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(y => y.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(z => z.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialSlider()
        {
            var values = context.SliderInfos.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialMenu() 
        {
            var values = context.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "Beklemede";
            context.Reservations.Add(reservation);
            ViewBag.v = "true";
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialOpenDayHour()
        {
            var values = context.OpenDayHours.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialInstagram()
        {
            return PartialView();
        }
        public PartialViewResult PartialNewSletter()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.productcount = context.Products.Count();
            ViewBag.chefcount = context.Chefs.Count();
            ViewBag.reservationcount = context.Reservations.Count();
            ViewBag.contactcount = context.Contacts.Count();
            return View();
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult Chef()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            return View();
        }

        public ActionResult Reservation()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.secret = context.Abouts.Select(x => x.Description).FirstOrDefault();
            return View();
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PartialContact(Contact contact)
        {
            contact.ReservationStatus = "Beklemede";
            context.Reservations.Add(contact);
            ViewBag.v = "true";
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}