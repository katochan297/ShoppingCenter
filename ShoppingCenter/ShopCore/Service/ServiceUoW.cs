using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCore.Repository;
using ShopData.Model;
using ShopData.Repository;

namespace ShopCore.Service
{
    public class ServiceUoW : IDisposable
    {
        private readonly ShoppingCenterContext _context = new ShoppingCenterContext();
        public IMenuRepository MenuRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IBannerRepository BannerRepository { get; private set; }


        public ServiceUoW()
        {
            MenuRepository = new MenuRepository(_context);
            ProductRepository = new ProductRepository(_context);
            BannerRepository = new BannerRepository(_context);
        }

       

        public void Commit()
        {
            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
