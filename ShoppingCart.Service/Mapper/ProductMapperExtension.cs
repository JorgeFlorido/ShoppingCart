using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public static class ProductMapperExtension
    {
        public static IList<ProductViewModel> ConvertToProductViewModel(this IList<Products> products)
        {
            IList<ProductViewModel> productsViewModel = new List<ProductViewModel>();

            foreach (Products p in products)
            {
                productsViewModel.Add(p.ConvertToProductViewModel());
            }

            return productsViewModel;
        }

        public static ProductViewModel ConvertToProductViewModel(this Products product)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Id = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.Quantity = product.Quantity >= 0? product.Quantity : 0;

            productViewModel.IsAvailable = product.Quantity > 0;

            return productViewModel;
        }

        public static Products ConvertToEntity(this ProductViewModel productVM)
        {
            Products product = new Products();

            product.Id = productVM.Id;
            product.Name = productVM.Name;
            product.Description = productVM.Description;
            product.Quantity = productVM.Quantity;

            return product;
        }
    }
}
