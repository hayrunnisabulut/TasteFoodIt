using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        TasteContext context = new TasteContext();
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult OpenMessage(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public ActionResult OpenMessage()
        {
            return RedirectToAction("ContactList");
        }
        public ActionResult UpdateContactIsRead(int id)
        {
            var value = context.Contacts.Find(id);
            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}