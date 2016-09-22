using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Enum;
using ShopData.Model;

namespace ShopCore.Service
{
    public class MenuService : BaseService
    {
        public async Task<List<Menu>> GetListMenu()
        {
            return await ContextInstance.Menus.Where(x => x.Status == DataStatus.Available).ToListAsync();
        }


    }
}
