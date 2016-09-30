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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext ctx) : base(ctx)
        {
        }
        

    }
}
