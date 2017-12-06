using ShoppingCart.Logic;
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
        private IProductService _productService;
        private IBuyLogic _buyLogic;

        public HomeController(IProductService productService, IBuyLogic buyLogic)
        {
            _productService = productService;
            _buyLogic = buyLogic;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}