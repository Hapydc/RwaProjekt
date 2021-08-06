using RWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA.WebForms
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var customer = Repository.GetCustomer(1);
            firstName.Value = customer.Ime;
            lastName.Value = customer.Prezime;
            email.Value = customer.Email;
            phone.Value = customer.Telefon;
            var towns = Repository.GetTowns(customer.Town.Country.IDDrzava);
            foreach (var item in towns)
            {
                dlTowns.Items.Add(item.Naziv);
            }


        }
    }
}