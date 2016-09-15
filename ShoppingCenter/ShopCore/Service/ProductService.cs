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
    public class ProductService : BaseService
    {
        public async Task<List<Product>> GetListProductLevel(int quantity)
        {
            return await ContextInstance.Products.Where(x => x.Status == DataStatus.Available).OrderByDescending(x => x.OrderLevel).Take(quantity).ToListAsync();
        }
    }
}