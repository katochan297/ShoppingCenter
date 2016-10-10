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
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        internal CategoryRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Category> GetAllByType(int typeId)
        {
            return Context.Set<Category>()
                .Include(x => x.Products)
                .Include(x => x.CategoryType)
                .Where(x => x.CategoryTypeID == typeId);
        }

    }
}
