using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class SubCategory
    {
        public int? IDPotKategorija { get; set; }

        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "Naziv je obvezan")]
        public string Naziv { get; set; }
        public int IDKategorija { get; set; }
        public int KategorijaID { get; set; }

    }
}