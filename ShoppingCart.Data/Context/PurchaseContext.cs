using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class PurchaseContext : DatabaseContext
    {
        public IEnumerable<Purchase> GetAllPurchases()
        {
            return Set<Purchase>();
        }

        public object GetPurchase(object entity)
        {
            return Entry(entity);
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
