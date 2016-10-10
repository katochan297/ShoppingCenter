using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Enum;
using ShopData.Model;
using ShopData.Repository;

namespace ShopCore.Repository
{
    internal class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        internal MenuRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Menu> GetAllAvailable()
        {
            return Context.Set<Menu>()
                .Include(x => x.Menu1)
                .Include(x => x.Menu2)
                .Where(x => x.Status == DataStatus.Available);
        }

        public IEnumerable<Menu> GetMenuParent()
        {
            return GetAllAvailable()
                .Where
                (
                    x => x.Status == DataStatus.Available &&
                         x.ParentID == null
                );
        }

    }
}
