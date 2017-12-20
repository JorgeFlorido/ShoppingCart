using ShoppingCart.Service;
using System;
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
            if (Request.QueryString["selectedUser"] != null)
            {
                Session["UserId"] = Request.QueryString["selectedUser"];
            }

            var items = _productService.GetAllProducts();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddToCart(ProductViewModel item)
        {
            if (Session["UserId"] != null)
            {
                item.BuyerId = Int32.Parse(Session["UserId"].ToString());
                _productService.AddToCart(item); 
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}