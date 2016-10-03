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
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        internal BannerRepository(DbContext ctx) : base(ctx)
        {
        }

    }
}
