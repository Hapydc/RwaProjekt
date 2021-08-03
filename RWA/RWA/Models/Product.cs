using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Product
    {
        public int IdProizvod { get; set; }
        public string Naziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public short MinKolicinaNaSkladistu { get; set; }
        public decimal CijenaBezPdva { get; set; }
        public int? PotKategorijaID { get; set; }
        public SubCategory Subcategory { get; set; }
    }
}