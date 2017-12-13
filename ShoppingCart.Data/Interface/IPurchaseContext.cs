using System.Collections.Generic;

namespace ShoppingCart.Data.Interface
{
    public interface IPurchaseContext
    {
        IEnumerable<Purchase> GetAllProducts();
        object GetProduct(object entity);
        int Save();
    }
}
