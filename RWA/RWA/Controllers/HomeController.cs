using RWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class HomeController : Controller
    {
      public ActionResult ShowCustomer()
        {
            var customers = Repository.SelectTop50Desc();
            return View(customers);
        }
        [HttpGet]
       public ActionResult EditCustomer(int id)
        {
            var customer = Repository.GetCustomer(id);
            return View(customer);
        } 
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            return RedirectToAction("ShowCustomer");
        }

    }
}