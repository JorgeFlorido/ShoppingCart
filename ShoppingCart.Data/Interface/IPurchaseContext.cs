using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IPurchaseContext
    {
        IEnumerable<Purchase> GetAllPurchases();
        object GetPurchase(object entity);
        int Save();
    }
}
