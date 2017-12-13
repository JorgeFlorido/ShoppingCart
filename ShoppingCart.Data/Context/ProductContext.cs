using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class ProductContext : DatabaseContext
    {
        public IEnumerable<Products> GetAllProducts()
        {
            return Set<Products>();
        }

        public object GetProduct(object entity)
        {
            return Entry(entity);
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
