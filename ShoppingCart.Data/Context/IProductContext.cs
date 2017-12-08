using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public interface IProductContext
    {
        IEnumerable<Products> GetProducts();
        object GetEntry(object entity);
        int Save();
    }
}
