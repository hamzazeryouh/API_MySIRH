using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class SiteService: ISiteService
    {

        private readonly ISiteRepository _SiteRepository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository SiteRepository, IMapper mapper)
        {
            this._SiteRepository = SiteRepository;
            this._mapper = mapper;
        }

        public async Task<SiteDTO> AddSite(SiteDTO Site)
        {
            var returnedSite = await this._SiteRepository.AddSite(this._mapper.Map<Site>(Site));
            return this._mapper.Map<SiteDTO>(returnedSite);
        }

        public async Task DeleteSite(int id)
        {
            await this._SiteRepository.DeleteSite(id);
        }

        public async Task<SiteDTO> GetSite(int id)
        {
            return this._mapper.Map<SiteDTO>(await this._SiteRepository.GetSite(id));
        }

        public async Task<IEnumerable<SiteDTO>> GetSites()
        {
            //var query = this._SiteRepository.GetSites().ProjectTo<SiteDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Site>, PagedList<SiteDTO>>(collabs);
            //return await PagedList<SiteDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _SiteRepository.GetSites();
            return _mapper.Map<IEnumerable<Site>, IEnumerable<SiteDTO>>(result);
        }

        public async Task UpdateSite(int id, SiteDTO Site)
        {
            await this._SiteRepository.UpdateSite(id, this._mapper.Map<Site>(Site));
        }
    }
}
