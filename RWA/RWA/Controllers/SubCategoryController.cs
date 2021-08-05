using RWA.Models;
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
            var subCategory = Repository.GetSubCategory(id);
            return View(subCategory);

        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory subCategory)
        {
            Repository.UpdateSubCategory(subCategory);
            return RedirectToAction("Index");
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

                Repository.InsertSubCategory(subCategory);
                return RedirectToAction("Index");
        }

        public ActionResult DeleteSubCategory(int id)
        {
            Repository.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }
    }
}