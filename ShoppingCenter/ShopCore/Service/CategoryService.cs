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
    public class CategoryService : BaseService
    {
        public async Task<List<Category>> GetListCategory()
        {
            return await ContextInstance.Categories.Where(x => x.Status == DataStatus.Available).ToListAsync();
        }
    }
}
