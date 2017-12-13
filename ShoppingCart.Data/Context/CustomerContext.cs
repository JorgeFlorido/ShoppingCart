using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class CustomerContext : DatabaseContext
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            return Set<Customer>();
        }

        public object GetCustomer(object entity)
        {
            return Entry(entity);
        }
    }
}
