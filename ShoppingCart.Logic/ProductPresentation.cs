using ShoppingCart.Core;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic
{
    public class ProductPresentation : IProductPresentation
    {
        private IProductService _productService;

        public ProductPresentation(IProductService productService)
        {
            _productService = productService;
        }
        public List<ProductViewModel> GetProductList()
        {
            List<ProductViewModel> productList = _productService.GetAllProducts();
            return productList;
        }
    }
}
