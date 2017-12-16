using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Data
{
    public class PurchaseRepository : DatabaseContext
    {
        public IEnumerable<Purchase> GetAll()
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

        public IEnumerable<Purchase> GetUserPurchases(int userId)
        {
            return Purchase.Where(x => x.CustomerID == userId);
        }

        public void Add(Purchase purchase)
        {
            Purchase.Add(purchase);
        }
    }
}
