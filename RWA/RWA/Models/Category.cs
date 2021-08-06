using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Category
    {
        
        public int IDKategorija { get; set; }
        [Required (ErrorMessage="Molimo unesite ispravan naziv")]
        public string Naziv { get; set; }

    }
}