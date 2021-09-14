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
        public int SortByType { get; set; }

        public List<Sort> Sorts { get; set; }

        public int Page { get; set; }

        public ShowCustomersVM()
        {
            Sorts = new List<Sort>();
            Sorts.Add(new Sort
            {
                ID=0,
                Naziv="Sortirajte po imenu padajuće"
            }
            );
            Sorts.Add(new Sort
            {
                ID = 1,
                Naziv = "Sortirajte po imenu uzlazno"
            }
           );
        }

    }
}