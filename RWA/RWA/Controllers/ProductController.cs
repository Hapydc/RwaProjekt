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

        public ActionResult EditProduct(int id)
        {
            var products = Repository.GetProducts();
            Product product = products.Find(e => e.IdProizvod == id);
            return View(product);
        }
    }
}