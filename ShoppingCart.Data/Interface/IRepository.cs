using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Update(T entity);
    }
}
