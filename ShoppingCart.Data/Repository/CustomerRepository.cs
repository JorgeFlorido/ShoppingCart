using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class CustomerRepository : DatabaseContext
    {
        public IEnumerable<Customer> GetAll()
        {
            return Set<Customer>();
        }
    }
}
