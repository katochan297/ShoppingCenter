using System;
using System.Collections.Generic;
using System.Linq;
using ShopCore.Repository;
using ShopCore.Service;
using ShopData.Model;

namespace ShopCore.Cache
{
    public class CacheManagement
    {
        private static readonly Lazy<CacheManagement> ObjLazy = new Lazy<CacheManagement>(() => new CacheManagement());
        public static CacheManagement Instance => ObjLazy.Value;

        public List<Banner> ListBanner;
        public List<Menu> ListMenu;
        public List<Product> ListProduct;

        protected CacheManagement()
        {
            ListBanner = new List<Banner>();
            ListMenu = new List<Menu>();
            ListProduct = new List<Product>();
        }


        public void Init()
        {
            using (var uow = new ServiceUoW())
            {
                ListMenu = uow.MenuRepository.GetListAvailable().ToList();
                ListBanner = uow.BannerRepository.GetAll().ToList();
                ListProduct = uow.ProductRepository.GetAll().ToList();
            }
        }


    }
}
