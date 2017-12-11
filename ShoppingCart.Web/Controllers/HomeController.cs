using ShoppingCart.Service;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var items = _productService.GetAllProducts();
            return View(items);
        }
    }
}