using ShoppingCart.Data;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDatabaseContext _productContext;
        private IProductService _productService;

        public HomeController(
            IDatabaseContext productContext,
            IProductService productService)
        {
            _productService = productService;
            _productContext = productContext;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}