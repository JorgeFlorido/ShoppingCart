using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        object GetCustomer(object entity);
    }
}
