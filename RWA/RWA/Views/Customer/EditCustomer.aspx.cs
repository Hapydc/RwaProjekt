using RWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA.WebForms
{
    public partial class EditCustomer : System.Web.Mvc.ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customer = Repository.GetCustomer((int)Session["CustomerID"]);
            firstName.Value = customer.Ime;
            lastName.Value = customer.Prezime;
            email.Value = customer.Email;
            phone.Value = customer.Telefon;
            var towns = Repository.GetTowns(1);
            foreach (var item in towns)
            {
                dlTowns.Items.Add(item.Naziv);
            }         
        }

        protected void editCustomerData_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                IDKupac = (int)Session["CustomerID"],
                Ime = firstName.Value,
                Prezime = lastName.Value,
                Email = email.Value,
                Telefon = phone.Value  
                
            };
            Repository.UpdateCustomer(customer);
        }
    }
}