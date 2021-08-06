using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.SubCategoryViewModel
{
    public class SubCategoryVM
    {
        public SubCategory subcategory { get; set; }
        public List<Category> categories { get; set; }
    }
}