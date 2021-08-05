﻿using RWA.Models;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = Repository.GetProducts();   
            return View(products);
        }


        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = Repository.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            
                Repository.UpdateProduct(product);
                return RedirectToAction("Index");
            
            //return EditProduct(product);
        }

        [HttpGet]
        public ActionResult InsertProduct()
        {
            Product product = new Product();
            return View(product);

        }

        [HttpPost]
        public ActionResult InsertProduct(Product product)
        {
            
                Repository.InsertProduct(product);
                return RedirectToAction("Index");
                     

        }
          
        public ActionResult DeleteProduct(int id)
        {
            Repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}