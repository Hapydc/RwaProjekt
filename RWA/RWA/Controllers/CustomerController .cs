using RWA.Models;
using RWA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var customers = Repository.GetAllCustomers();
            return View(customers);
        }

        public ActionResult SelectCountry()
        {
            var model = Repository.GetCountries();
            return View(model);
        }

        public ActionResult SelectTown(Country country)
        {
            var model = new SelectTownVM
            {
                Countries = Repository.GetCountries(),
                Towns = Repository.GetTowns(country.IDDrzava)
            };
            return View(model);
        }

        public ActionResult GetFilteredCustomers(Town town)
        {

            var IdTown = town.IDGrad;
            var idCountry = Repository.GetTown(IdTown).DrzavaID;
            var model = new ShowCustomersVM
            {
                Countries = Repository.GetCountries(),
                Towns = Repository.GetTowns(idCountry),
                Customers = Repository.GetFilteredCustomers(IdTown),
                IDCountry=idCountry,
                IDTown=IdTown
            };
            return View(model);
        }

        public ActionResult GetCustomersBills(int id)
        {
            var bills = Repository.GetCustomersBills(id);
            return View(bills);
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            Customer c = Repository.GetCustomer(id);
            var customer = new EditCustomerVM
            {
                Customer = c,
                Towns = Repository.GetTowns(1),
                TownID = c.GradID

            };
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(EditCustomerVM customerVM)
        {
            var customer = customerVM.Customer;
            Repository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

    }
}