using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);

    }
}
