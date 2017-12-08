using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class ProductContext : DatabaseContext
    {
        public IEnumerable<Products> GetProducts()
        {
            return Set<Products>();
        }

        public object GetEntry(object entity)
        {
            return Entry(entity);
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
