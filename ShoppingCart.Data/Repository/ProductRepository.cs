using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoppingCart.Data
{
    public class ProductRepository : DatabaseContext
    {
        public IEnumerable<Products> GetAll()
        {
            return Set<Products>();
        }

        public Products Get(int id)
        {
            return Set<Products>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Products entity)
        {
            if (entity != null)
            {
                Entry(entity).State = EntityState.Modified;
                SaveChanges(); 
            }
        }
    }
}
