using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetById(int id);
        void Update(ProductViewModel itemId);
    }
}
