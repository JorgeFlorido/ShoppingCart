using ShoppingCart.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICustomerService _customerService;

        public ProductController(
            IProductService productService,
            ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        public ActionResult ProductList()
        {
            var items = _productService.GetAllProducts();
            IEnumerable<CustomerViewModel> users = _customerService.GetAllCustomers();
            ViewBag.UserList = new SelectList(users);
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