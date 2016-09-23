using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ShopData.Model;

namespace ShopCore.Service
{
    public class BannerService : BaseService
    {
        public async Task<List<Banner>> GetListBanner()
        {
            return await ContextInstance.Banners.ToListAsync();
        }

        public async Task<Banner> FindBanner(int id)
        {
            var banner = await ContextInstance.Banners.FindAsync(id);
            return banner;
        }
        
        public async Task<int> CreateBanner(Banner banner)
        {
            ContextInstance.Banners.Add(banner);
            return await ContextInstance.SaveChangesAsync();
        }

        public async Task<int> UpdateBanner(Banner banner)
        {
            ContextInstance.Entry(banner).State = EntityState.Modified;
            return await ContextInstance.SaveChangesAsync();
        }

        public async Task<int> DeleteBanner(int id)
        {
            var banner = await ContextInstance.Banners.FindAsync(id);
            ContextInstance.Banners.Remove(banner);
            return await ContextInstance.SaveChangesAsync();
        }
        
    }
}