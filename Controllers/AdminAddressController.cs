using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminAddressController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AddressList()
        {
            var values = context.Addresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var value = context.Addresses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAddress(Address address)
        {
            var value = context.Addresses.Find(address.AddressId);
            value.Description = address.Description;
            value.Phone = address.Phone;
            value.Email = address.Email;
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}