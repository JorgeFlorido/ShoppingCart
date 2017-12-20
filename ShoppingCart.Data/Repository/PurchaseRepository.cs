using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoppingCart.Data
{
    public class PurchaseRepository : DatabaseContext
    {
        public Purchase Get(int id)
        {
            return Set<Purchase>().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Purchase> GetUserPurchases(int userId)
        {
            return Set<Purchase>().Where(x => x.CustomerID == userId && x.Finished == false);
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
