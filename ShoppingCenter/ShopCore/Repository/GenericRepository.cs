using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.Model;
using ShopData.Repository;

namespace ShopCore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _dbSet;

        internal GenericRepository(DbContext ctx)
        {
            Context = ctx;
            _dbSet = Context.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entityTodelete = FindById(id);
            Delete(entityTodelete);
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

    }
}
