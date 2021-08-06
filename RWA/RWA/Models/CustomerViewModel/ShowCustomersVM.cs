using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.ViewModel
{
    public class ShowCustomersVM
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Town> Towns { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public List<int> Pages { get; set; }

    }
}