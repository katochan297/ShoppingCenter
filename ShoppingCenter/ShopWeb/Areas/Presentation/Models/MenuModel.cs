using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopCore.Enum;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Models
{
    public class MenuModel
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public List<MenuCatalog> ListCatalog { get; set; }
        public MenuActivated Activated { get; set; }
    }
    

    public class MenuCatalog
    {
        public Category Category { get; set; }
        public List<Subcategory> ListSubcategory { get; set; }
    }
}