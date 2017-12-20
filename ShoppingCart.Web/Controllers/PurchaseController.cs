using ShoppingCart.Service;
using System;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseService _purchaseService;
        private ICustomerService _customerService;

        public PurchaseController(
            IPurchaseService purchaseService,
            ICustomerService customerService)
        {
            _purchaseService = purchaseService;
            _customerService = customerService;
        }

        // GET: Purchase
        public ActionResult SelectUserCart()
        {
            var items = _customerService.GetAllCustomers();
            return View(items);
        }

        public ActionResult UserCart()
        {
            if (Request.QueryString["selectedUser"] != null)
            {
                Session["UserId"] = Request.QueryString["selectedUser"];
                var id = Session["UserId"].ToString();
                var items = _purchaseService.GetUserPurchases(Int32.Parse(id));
                return View(items);
            }

            return View();
        }

        public ActionResult Checkout()
        {
            if (Session["UserId"] != null)
            {
                var id = Session["UserId"].ToString();
                var items = _purchaseService.GetUserPurchases(Int32.Parse(id));
                _purchaseService.FinishPurchases(items);
            }

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}