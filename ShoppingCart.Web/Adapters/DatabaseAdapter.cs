using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Web
{
    public class DatabaseAdapter : DatabaseContext, IDatabaseContext
    {
    }
}