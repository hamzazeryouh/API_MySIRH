

namespace API_MySIRH.Services
{
    using API_MySIRH.DTOs;
    using API_MySIRH.DTOs.MDM;
    using API_MySIRH.Entities;
    using API_MySIRH.Entities.MDM;
    using API_MySIRH.Interfaces;
    using API_MySIRH.Interfaces.InterfaceServices.MDM;
    using AutoMapper;
    public class PosteNiveauService: IPosteNiveauService
    {
        private readonly IPosteNiveauRepository _PosteNiveauRepository;
        private readonly IMapper _mapper;

        public PosteNiveauService(IPosteNiveauRepository PosteNiveauRepository, IMapper mapper)
        {
            this._PosteNiveauRepository = PosteNiveauRepository;
            this._mapper = mapper;
        }

        public async Task<PosteNiveauDTO> AddPosteNiveau(PosteNiveauDTO PosteNiveau)
        {
            var returnedPosteNiveau = await this._PosteNiveauRepository.AddPosteNiveau(this._mapper.Map<PosteNiveau>(PosteNiveau));
            return this._mapper.Map<PosteNiveauDTO>(returnedPosteNiveau);
        }

        public async Task DeletePosteNiveau(int id)
        {
            await this._PosteNiveauRepository.DeletePosteNiveau(id);
        }

        public async Task<PosteNiveauDTO> GetPosteNiveau(int id)
        {
            return this._mapper.Map<PosteNiveauDTO>(await this._PosteNiveauRepository.GetPosteNiveau(id));
        }

        public async Task<IEnumerable<PosteNiveauDTO>> GetPosteNiveaus()
        {
            //var query = this._PosteNiveauRepository.GetPosteNiveaus().ProjectTo<PosteNiveauDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<PosteNiveau>, PagedList<PosteNiveauDTO>>(collabs);
            //return await PagedList<PosteNiveauDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _PosteNiveauRepository.GetPosteNiveaus();
            return _mapper.Map<IEnumerable<PosteNiveau>, IEnumerable<PosteNiveauDTO>>(result);
        }

        public async Task UpdatePosteNiveau(int id, PosteNiveauDTO PosteNiveau)
        {
            await this._PosteNiveauRepository.UpdatePosteNiveau(id, this._mapper.Map<PosteNiveau>(PosteNiveau));
        }
    }
}

