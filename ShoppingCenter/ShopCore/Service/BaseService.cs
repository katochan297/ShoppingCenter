using System;
using ShopData.Model;

namespace ShopCore.Service
{
    public abstract class BaseService
    {
        private static readonly Lazy<ShoppingCenterContext> ObjLazy = new Lazy<ShoppingCenterContext>(() => new ShoppingCenterContext());

        protected static ShoppingCenterContext ContextInstance => ObjLazy.Value;
        
        protected void DisposeContext()
        {
            ContextInstance.Dispose();
        }
    }
}
