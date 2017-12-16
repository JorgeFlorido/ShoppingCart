using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAll();
        object Get(object entity);
        int Save();
        IEnumerable<Purchase> GetUserPurchases(int userId);
        void Add(Purchase purchase);
    }
}
