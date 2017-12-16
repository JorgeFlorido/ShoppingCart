using ShoppingCart.Data;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IPurchaseRepository _purchaseRespository;

        public ProductService(
            IProductRepository productRepository,
            IPurchaseRepository purchaseRepository)
        {
            _productRepository = productRepository;
            _purchaseRespository = purchaseRepository;
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
                Products product = _productRepository.Get(id);
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

        public bool AddToCart(ProductViewModel item, int customerId)
        {
            Products product = _productRepository.Get(item.Id);
            Purchase purchase = new Purchase();

            bool canBuy = (product != null && product.Quantity > 0 && product.Quantity >= item.QuantityToBuy);

            if (canBuy)
            {
                purchase.ProductID = item.Id;
                purchase.CustomerID = customerId;
                purchase.Finished = false;
                _purchaseRespository.Add(purchase);
            }

            return canBuy;
        }
    }
}
