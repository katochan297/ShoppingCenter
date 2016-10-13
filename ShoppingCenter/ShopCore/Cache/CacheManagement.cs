using System;
using System.Collections.Generic;
using System.Linq;
using ShopCore.Enum;
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
        public List<MaskProduct> ListMaskProduct;
        public List<Category> ListMaskCategory;


        protected CacheManagement()
        {
            ListBanner = new List<Banner>();
            ListMenu = new List<Menu>();
            ListProduct = new List<Product>();
            ListMaskProduct = new List<MaskProduct>();
            ListMaskCategory = new List<Category>();
        }


        public void Init()
        {
            using (var uow = new ServiceUoW())
            {
                ListMenu = uow.MenuRepository.GetAllAvailable().ToList();
                ListBanner = uow.BannerRepository.GetAll().ToList();
                ListProduct = uow.ProductRepository.GetAllAvailable().ToList();

                ListMaskProduct = uow.MaskProductRepository.GetAllAvailable().ToList();

                var type = uow.CategoryTypeRepository.FindByName(Discriminator.Mask);
                var typeId = type?.CategoryTypeID ?? -1;
                ListMaskCategory = uow.CategoryRepository.GetAllByType(typeId).ToList();
            }
        }


    }
}
