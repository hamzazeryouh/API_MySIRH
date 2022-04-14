using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class SkillCenterService: ISkillCenterService
    {

        private readonly ISkillCenterRepository _SkillCenterRepository;
        private readonly IMapper _mapper;

        public SkillCenterService(ISkillCenterRepository SkillCenterRepository, IMapper mapper)
        {
            this._SkillCenterRepository = SkillCenterRepository;
            this._mapper = mapper;
        }

        public async Task<SkillCenterDTO> AddSkillCenter(SkillCenterDTO SkillCenter)
        {
            var returnedSkillCenter = await this._SkillCenterRepository.AddSkillCenter(this._mapper.Map<SkillCenter>(SkillCenter));
            return this._mapper.Map<SkillCenterDTO>(returnedSkillCenter);
        }

        public async Task DeleteSkillCenter(int id)
        {
            await this._SkillCenterRepository.DeleteSkillCenter(id);
        }

        public async Task<SkillCenterDTO> GetSkillCenter(int id)
        {
            return this._mapper.Map<SkillCenterDTO>(await this._SkillCenterRepository.GetSkillCenter(id));
        }

        public async Task<IEnumerable<SkillCenterDTO>> GetSkillCenters()
        {
            //var query = this._SkillCenterRepository.GetSkillCenters().ProjectTo<SkillCenterDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<SkillCenter>, PagedList<SkillCenterDTO>>(collabs);
            //return await PagedList<SkillCenterDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _SkillCenterRepository.GetSkillCenters();
            return _mapper.Map<IEnumerable<SkillCenter>, IEnumerable<SkillCenterDTO>>(result);
        }

        public async Task UpdateSkillCenter(int id, SkillCenterDTO SkillCenter)
        {
            await this._SkillCenterRepository.UpdateSkillCenter(id, this._mapper.Map<SkillCenter>(SkillCenter));
        }
    }
}
