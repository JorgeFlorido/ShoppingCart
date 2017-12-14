using ShoppingCart.Service;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class UserController : Controller
    {
        private ICustomerService _customerService;

        public UserController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult UserLogin()
        {
            var users = _customerService.GetAllCustomers();
            return View(users);
        }
    }
}