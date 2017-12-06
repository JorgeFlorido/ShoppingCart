using System.Collections.Generic;

namespace ShoppingCart.Service
{
    public class ProductResponse : BaseResponse, IProductResponse
    {
        public IList<ProductViewModel> Products { get; set; }
    }
}
