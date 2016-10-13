using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.Model;
using ShopData.Repository;

namespace ShopCore.Repository
{
    internal class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        internal OrderRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}
