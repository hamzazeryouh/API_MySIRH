using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetSites();
        Task<Site> GetSite(int id);
        Task UpdateSite(int id, Site Site);
        Task<Site> AddSite(Site Site);
        Task DeleteSite(int id);
        Task<bool> SiteExists(int id);
    }
}
