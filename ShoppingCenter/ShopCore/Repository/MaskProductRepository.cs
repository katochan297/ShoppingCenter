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
                .Where(x => x.Status == DataStatus.Available)
                .ToList();
        }

        public IEnumerable<MaskProduct> GetByCategory(int categoryId)
        {
            return Context.Set<MaskProduct>()
                .Include(x => x.ProductImages)
                .Where(
                    x => x.Status == DataStatus.Available && 
                    x.CategoryID == categoryId)
                .ToList();
        }

        public IEnumerable<MaskProduct> GetByListCategory(int[] lstCategoryId)
        {
            return Context.Set<MaskProduct>()
                .Include(x => x.ProductImages)
                .Where(
                    x =>
                        x.Status == DataStatus.Available &&
                        lstCategoryId.Contains(x.CategoryID ?? -1))
                .ToList();
        }

    }

}
