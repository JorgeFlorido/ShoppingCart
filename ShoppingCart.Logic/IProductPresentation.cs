﻿using ShoppingCart.Core;
using ShoppingCart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic
{
    public interface IProductPresentation
    {
        List<ProductViewModel> GetProductList();
    }
}
