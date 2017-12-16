using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Data
{
    public class PurchaseRepository : DatabaseContext
    {
        public IEnumerable<Purchase> GetUserPurchases(int userId)
        {
            return Set<Purchase>().Where(x => x.CustomerID == userId);
        }

        public void Add(Purchase purchase)
        {
            if (purchase != null)
            {
                Purchase.Add(purchase);
                SaveChanges(); 
            }
        }
    }
}
