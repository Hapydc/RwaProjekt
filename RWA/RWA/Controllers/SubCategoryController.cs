using RWA.Models;
using RWA.Models.SubCategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public ActionResult Index()
        {
            var subcategories = Repository.GetSubCategories();   
            return View(subcategories);
        }


        [HttpGet]
        public ActionResult EditSubCategory(int id)
        {

            var subCategory = new SubCategoryVM
            {
                subcategory = Repository.GetSubCategory(id),
                categories = Repository.GetCategories()
            };
            return View(subCategory);

        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                //subCategory.KategorijaID = ;
                Repository.UpdateSubCategory(subCategory);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditSubCategory");
            }
            
        }

        [HttpGet]
        public ActionResult InsertSubCategory()
        {
            SubCategory subCategory = new SubCategory();
            return View(subCategory);

        }

        [HttpPost]
        public ActionResult InsertSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                Repository.InsertSubCategory(subCategory);
                return RedirectToAction("Index");
            }
            return RedirectToAction("InsertSubCategory");
        }

        public ActionResult DeleteSubCategory(int id)
        {
            Repository.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }
    }
}