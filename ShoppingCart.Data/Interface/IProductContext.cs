using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IProductContext
    {
        IEnumerable<Products> GetAllProducts();
        object GetProduct(object entity);
        int Save();
    }
}
