using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public interface ICustomerService
    {
        CustomerListViewModel GetAllCustomers();
    }
}
