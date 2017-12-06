using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic
{
    public class BuyLogic
    {
        private IProductService _productService;

        public BuyLogic(IProductService productService)
        {
            _productService = productService;
        }
        public void BuyItem(int itemId)
        {
            if (itemId > 0)
            {
                var item = _productService.GetById(itemId);

                if (item != null && item.IsAvailable)
                {
                    item.Quantity--;
                    _productService.Update(item);
                }
            }
        }
    }
}
