﻿using ShoppingCart.Service;
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
            TempData["UserId"] = Request.QueryString["selectedUser"];
            var items = _productService.GetAllProducts();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddToCart(ProductViewModel item)
        {
            var id = Int32.Parse(TempData["UserId"].ToString());
            _productService.AddToCart(item, id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}