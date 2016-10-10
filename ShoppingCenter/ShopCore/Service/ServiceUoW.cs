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
        public IBannerRepository BannerRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IMaskProductRepository MaskProductRepository { get; private set; }
        public ICategoryTypeRepository CategoryTypeRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }


        public ServiceUoW()
        {
            MenuRepository = new MenuRepository(_context);
            BannerRepository = new BannerRepository(_context);
            ProductRepository = new ProductRepository(_context);
            MaskProductRepository = new MaskProductRepository(_context);
            CategoryTypeRepository = new CategoryTypeRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
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
