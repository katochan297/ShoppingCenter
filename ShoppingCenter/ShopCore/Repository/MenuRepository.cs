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
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Menu> GetListAvailable()
        {
            return Context.Set<Menu>().Where(x => x.Status == DataStatus.Available).ToList();
        }


    }
}
