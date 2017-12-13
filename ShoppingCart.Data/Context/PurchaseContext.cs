using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class PurchaseContext : DatabaseContext
    {
        public IEnumerable<Purchase> GetAllCustomers()
        {
            return Set<Purchase>();
        }

        public object GetCustomer(object entity)
        {
            return Entry(entity);
        }
    }
}
