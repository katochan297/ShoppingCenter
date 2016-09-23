using System;
using System.Collections.Generic;
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


        public async void Init()
        {
            ListBanner = await new BannerService().GetListBanner();
            ListMenu = await new MenuService().GetListMenu();
            ListProduct = await new ProductService().GetListProduct();
        }


    }
}
