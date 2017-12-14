using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDatabaseContext _context = null;
        private IDbSet<T> _dbSet;

        public Repository(IDatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
