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

        public ProductResponse GetAllProducts()
        {
            ProductResponse response = new ProductResponse();

            try
            {
                IList<Products> productEntities = _productRepository.GetAll().ToList();
                response.Products = productEntities.ConvertToProductViewModel();
                response.Confirm(true, "OK");
            }
            catch (Exception e)
            {
                response.Confirm(false, e.ToString());
            }

            return response;
        }

        public ProductResponse GetById(int id)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                Products product = _productRepository.GetById(id);
                response.Products.Add(product.ConvertToProductViewModel());
                response.Confirm(true, "OK");
            }
            catch (Exception e)
            {
                response.Confirm(false, e.ToString());
            }

            return response;
        }

        public ProductResponse Update(int id)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                Products product = _productRepository.GetById(id);
                response.Products.Add(product.ConvertToProductViewModel());
                response.Confirm(true, "OK");
            }
            catch (Exception e)
            {
                response.Confirm(false, e.ToString());
            }

            return response;
        }
    }
}
