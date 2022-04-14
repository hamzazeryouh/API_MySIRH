

namespace API_MySIRH.Services
{
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    public class CandidatService: ICandidatService
    {
        private readonly ICandidatRepository _CandidatRepository;
        private readonly IMapper _mapper;

        public CandidatService(ICandidatRepository CandidatRepository, IMapper mapper)
        {
            this._CandidatRepository = CandidatRepository;
            this._mapper = mapper;
        }

        public async Task<CandidatDTO> AddCandidat(CandidatDTO Candidat)
        {
            var returnedCandidat = await this._CandidatRepository.AddCandidat(this._mapper.Map<Candidat>(Candidat));
            return this._mapper.Map<CandidatDTO>(returnedCandidat);
        }

        public async Task DeleteCandidat(int id)
        {
            await this._CandidatRepository.DeleteCandidat(id);
        }

        public async Task<CandidatDTO> GetCandidat(int id)
        {
            return this._mapper.Map<CandidatDTO>(await this._CandidatRepository.GetCandidat(id));
        }

        public async Task<IEnumerable<CandidatDTO>> GetCandidats()
        {
            //var query = this._CandidatRepository.GetCandidats().ProjectTo<CandidatDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Candidat>, PagedList<CandidatDTO>>(collabs);
            //return await PagedList<CandidatDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _CandidatRepository.GetCandidats();
            return _mapper.Map<IEnumerable<Candidat>, IEnumerable<CandidatDTO>>(result);
        }

        public async Task UpdateCandidat(int id, CandidatDTO Candidat)
        {
            await this._CandidatRepository.UpdateCandidat(id, this._mapper.Map<Candidat>(Candidat));
        }
    }
}

