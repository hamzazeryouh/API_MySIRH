using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly DataContext _context;


        public SiteRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Site> AddSite(Site Site)
        {
            await this._context.Sites.AddAsync(Site);
            await this._context.SaveChangesAsync();
            return Site;
        }

        public async Task<bool> SiteExists(int id)
        {
            return await this._context.Sites.AnyAsync(Site => Site.Id == id);
        }

        public async Task DeleteSite(int id)
        {
            var SiteToDelete = await this._context.Sites.FindAsync(id);
            if (SiteToDelete is not null)
                this._context.Sites.Remove(SiteToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            return await this._context.Sites.ToListAsync();
        }

        public async Task<Site> GetSite(int id)
        {
            return  await _context.Sites.FindAsync(id);
        }

        public async Task UpdateSite(int id, Site Site)
        {
            this._context.Entry(Site).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }


}
