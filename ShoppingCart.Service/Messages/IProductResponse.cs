﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public interface IProductResponse
    {
        IList<ProductViewModel> Products { get; set; }
    }
}