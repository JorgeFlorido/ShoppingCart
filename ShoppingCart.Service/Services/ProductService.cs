using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Products> _productRepository;

        public ProductService(IRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            IEnumerable<ProductViewModel> itemList = new List<ProductViewModel>();

            try
            {
                IEnumerable<Products> products = _productRepository.GetAll();
                itemList = products.ConvertToProductViewModel();
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {                
            }
        }

        public bool AddToCart(ProductViewModel item)
        {
            Products product = _productRepository.GetById(item.Id);

            bool canBuy = (product != null && product.Quantity > 0);

            if (canBuy)
            {
                product.Quantity--;
                _productRepository.Update(product);
            }

            return canBuy;
        }
    }
}
