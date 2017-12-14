using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetAllCustomers();
    }
}
