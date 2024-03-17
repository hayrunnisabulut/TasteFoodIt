using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        TasteContext context = new TasteContext();
        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            value.ReservationStatus = "Reddedildi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");

        }
        public ActionResult ApproveReservation(int id)
        {
            var value = context.Reservations.Find(id);
            value.ReservationStatus = "Onaylandı";
            context.SaveChanges();
            return RedirectToAction("ReservationList");

        }
        public ActionResult WaitReservation(int id)
        {
            var value = context.Reservations.Find(id);
            value.ReservationStatus = "Beklemede";
            context.SaveChanges();
            return RedirectToAction("ReservationList");

        }

        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var value = context.Reservations.Find(reservation.ReservationId);
            value.ReservationStatus = reservation.ReservationStatus;
            value.Email = reservation.Email;
            value.Phone= reservation.Phone;
            value.ReservationDate = reservation.ReservationDate;
            value.Name = reservation.Name;
            value.Time = reservation.Time;
            value.GuestCount = reservation.GuestCount;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}