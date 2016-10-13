using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.Model;
using ShopCore.Enum;
using ShopData.Repository;

namespace ShopCore.Repository
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        internal ProductRepository(DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Product> GetAllAvailable()
        {
            return Context.Set<Product>()
                .Include(x => x.ProductImages)
                .Include(x => x.Category)
                .Include(x => x.CartDetails)
                .Where(x => x.Status == DataStatus.Available);
        }

    }
}
