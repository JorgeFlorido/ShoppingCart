using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface ICustomerContext
    {
        IEnumerable<Customer> GetAllCustomers();
        object GetCustomer(object entity);
    }
}
