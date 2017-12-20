using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetUserPurchases(int id);
        void Add(Purchase purchase);
        void Update(object entity);
        Purchase Get(int id);
    }
}
