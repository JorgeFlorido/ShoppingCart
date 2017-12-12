using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetById(int id);
        void Update(ProductViewModel itemId);
        bool AddToCart(ProductViewModel product);
    }
}
