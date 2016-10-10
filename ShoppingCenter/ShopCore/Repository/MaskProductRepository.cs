using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Enum;
using ShopData.Model;
using ShopData.Repository;

namespace ShopCore.Repository
{
    internal class MaskProductRepository : GenericRepository<MaskProduct>, IMaskProductRepository
    {
        internal MaskProductRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<MaskProduct> GetAllAvailable()
        {
            return Context.Set<MaskProduct>()
                .Include(x => x.ProductImages)
                .Include(x => x.Category)
                .Where(x => x.Status == DataStatus.Available);
        }

        public IEnumerable<MaskProduct> GetByCategory(int categoryId)
        {
            return GetAllAvailable()
                .Where(x => x.CategoryID == categoryId);
        }

        public IEnumerable<MaskProduct> GetByListCategory(int[] listCategoryId)
        {
            return GetAllAvailable()
                .Where
                (
                    x => x.Status == DataStatus.Available &&
                         listCategoryId.Contains(x.CategoryID ?? -1)
                );
        }

        public IEnumerable<MaskProduct> GetOrderbyLevel(int size)
        {
            return GetAllAvailable()
                .OrderByDescending(x => x.OrderLevel).Take(size);
        }


    }

}
