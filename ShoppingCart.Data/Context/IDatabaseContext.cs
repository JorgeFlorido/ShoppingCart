using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public interface IDatabaseContext
    {
        DbSet<Products> Products { get; set; }
    }
}
