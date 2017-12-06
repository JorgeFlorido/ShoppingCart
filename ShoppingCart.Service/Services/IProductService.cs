using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    interface IProductService
    {
        ProductResponse GetAllProducts();
        ProductResponse GetById(int id);
    }
}
