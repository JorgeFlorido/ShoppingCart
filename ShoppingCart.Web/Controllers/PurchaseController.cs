using ShoppingCart.Service;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: Purchase
        public ActionResult UserPurchases(int id)
        {
            var items = _purchaseService.GetUserPurchases(id);
            return View(items);
        }
    }
}