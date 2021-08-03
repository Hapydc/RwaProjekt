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
       
        public ActionResult GetFilteredCustomers(FilterModel filterModel)
        {
            if (filterModel.CustomersPerPage==0)
            {
                filterModel.CustomersPerPage = 10;
            }
            if (filterModel.Page==0)
            {
                filterModel.Page = 1;
            }
            var model = new ShowCustomersVM
            {
                Countries = Repository.GetCountries(),
                Towns = Repository.GetTowns(filterModel.IDDrzava),
                Customers = Repository.GetCustomers(filterModel.IDDrzava, filterModel.IDGrad, filterModel.SortByType, filterModel.CustomersPerPage, filterModel.Page)
            };
            return View(model);
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
            customer.IDKupac = 1;
            customer.Ime = "Ivica";
            Repository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }


        public ActionResult GetProducts()
        {
            var products = Repository.GetProducts();
            return View(products);
        }

    }
}