﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AdminLayoutController : Controller
    {
        TasteContext context = new TasteContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            var values = context.Notifications.Where(x => x.IsRead == false).ToList();
            ViewBag.notificationIsReadByFalseCount = values.Count();
            return PartialView(values);
        }
        public PartialViewResult PartialNavbarMessage()
        {
            var values = context.Contacts.Where(x => x.IsRead == false).ToList();
            ViewBag.messageIsReadFalseCount = values.Count();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("NotificationList", "Notification");
        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("ContactList", "Contact");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}