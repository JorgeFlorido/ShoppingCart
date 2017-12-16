using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
    }
}
