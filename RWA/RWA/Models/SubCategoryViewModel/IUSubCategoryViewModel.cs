using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.SubCategoryViewModel
{
    public class IUSubCategoryViewModel
    {
        public bool IsInsert { get; set; }
        public SubCategory subCategory { get; set; }
        public List<Category> Categories { get; set; }
        

        public IUSubCategoryViewModel(bool isInsert, SubCategory SubCategory, List<Category> categories)
        {
            IsInsert = isInsert;
            subCategory = SubCategory;
            Categories = categories;
        }

        public string Title
        {
            get
            {
                return IsInsert ? "Unos potkategorije" : "Izmjena potkategorije";
            }
        }

        public string ActionMetod
        {
            get
            {
                return IsInsert ? "InsertSubCategory" : "UpdateSubCategory";
            }
        }
    }
}