using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ISiteService
    {
        Task<IEnumerable<SiteDTO>> GetSites();
        Task<SiteDTO> GetSite(int id);
        Task UpdateSite(int id, SiteDTO Site);
        Task<SiteDTO> AddSite(SiteDTO Site);
        Task DeleteSite(int id);
    }
}
