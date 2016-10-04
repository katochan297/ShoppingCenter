using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.Model;

namespace ShopData.Repository
{
    public interface IMaskProductRepository : IGenericRepository<MaskProduct>
    {
        IEnumerable<MaskProduct> GetAllAvailable();
        IEnumerable<MaskProduct> GetByCategory(int categoryId);
        IEnumerable<MaskProduct> GetByListCategory(int[] lstCategoryId);
    }
}
