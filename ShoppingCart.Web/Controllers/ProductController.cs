using ShoppingCart.Service;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult ProductList()
        {
            var items = _productService.GetAllProducts();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddToCart(ProductViewModel item)
        {
            _productService.AddToCart(item);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}