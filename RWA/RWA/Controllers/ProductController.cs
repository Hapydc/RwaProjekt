using RWA.Models;
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
            var products = Repository.GetProducts();
            Product product = products.Find(e => e.IdProizvod == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            Repository.UpdateProduct(product);
            return RedirectToAction("Index");
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
    }
}