using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.ViewModel
{
    public class SelectTownVM
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Town> Towns { get; set; }
    }
}