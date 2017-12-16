using System.Data.Entity;

namespace ShoppingCart.Data
{
    public class DatabaseContext : ShopEntities, IDatabaseContext
    {
        public void Update(object entity)
        {
            if (entity != null)
            {
                Entry(entity).State = EntityState.Modified;
                SaveChanges();
            }
        }
    }
}
