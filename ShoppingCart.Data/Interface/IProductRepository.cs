using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Products Get(int id);
        void Update(object entity);
    }
}
