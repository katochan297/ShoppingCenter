using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ShopCore.Enum;
using ShopData.Model;

namespace ShopCore.Service
{
    public class SubcategoryService : BaseService
    {
        public async Task<List<Subcategory>> GetListSubcategoryByParent(int parentId)
        {
            return
                await
                    ContextInstance.Subcategories.Where(x => x.Status == DataStatus.Available && x.ParentID == parentId)
                        .ToListAsync();
        }
    }
}
