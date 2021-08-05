﻿using RWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers 
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = Repository.GetCategories();
            return View(categories);
        }


        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = Repository.GetCategory(id);           
            return View(category);

        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            Repository.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult InsertCategory()
        {
            Category category = new Category();
            return View(category);

        }

        [HttpPost]
        public ActionResult InsertCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                Repository.InsertCategory(category);
                return RedirectToAction("Index");
            }
            return InsertCategory(category);

        }

        public ActionResult DeleteCategory(int id)
        {
            Repository.DeleteCategory(id);
            return RedirectToAction("Index");
        }


    }
}