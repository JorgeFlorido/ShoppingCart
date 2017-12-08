using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ShoppingCart.Data
{
    public interface IDatabaseContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
