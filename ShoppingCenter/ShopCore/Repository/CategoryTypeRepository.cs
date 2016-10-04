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
    internal class CategoryTypeRepository : GenericRepository<CategoryType>, ICategoryTypeRepository
    {
        internal CategoryTypeRepository(DbContext ctx) : base(ctx)
        {
        }

        public CategoryType FindByName(string name)
        {
            return Context.Set<CategoryType>()
                .FirstOrDefault(x => x.TypeName.Contains(name));
        }

    }
}
