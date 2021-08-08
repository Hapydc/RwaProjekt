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
            var model = Repository.GetCountries();
            return View(model);
        }
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
        public ActionResult GetCustomersBills(int id)
        {
            var bills = Repository.GetCustomersBills(id);
            return View(bills);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            Session["CustomerID"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult EditCustomer(EditCustomerVM customerVM)
        {
            var customer = customerVM.Customer;
            customer.IDKupac = (int)Session["CustomerID"];        
            Repository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }
        public ActionResult ShowStavke(int id)
        {
            var stavke = Repository.GetStavke(id);
            return View(stavke);
        }
    }
}