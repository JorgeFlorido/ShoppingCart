using ShoppingCart.Core;
using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Products> _productRepository;

        public ProductService(IRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> itemList = new List<ProductViewModel>();

            try
            {
                IList<Products> products = _productRepository.GetAll().ToList();
                itemList = products.ConvertToProductViewModel().ToList();
            }
            catch (Exception e)
            {
            }

            return itemList;
        }

        public ProductViewModel GetById(int id)
        {
            ProductViewModel item = new ProductViewModel();

            try
            {
                Products product = _productRepository.GetById(id);
                item = product.ConvertToProductViewModel();
            }
            catch (Exception e)
            {
            }

            return item;
        }

        public void Update(ProductViewModel item)
        {
            try
            {
                Products product = item.ConvertToEntity();
                _productRepository.Update(product);
            }
            catch (Exception e)
            {                
            }
        }
    }
}
