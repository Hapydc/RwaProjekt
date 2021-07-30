using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.ViewModel
{
    public class EditCustomerVM
    {
        public Customer Customer { get; set; }

        public List<Town> Towns { get; set; }

        public int TownID { get; set; } 


    }
}