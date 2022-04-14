

namespace API_MySIRH.Services
{
    using API_MySIRH.DTOs;
    using API_MySIRH.DTOs.MDM;
    using API_MySIRH.Entities;
    using API_MySIRH.Entities.MDM;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    public class PosteService: IPosteService
    {
        private readonly IPosteRepository _PosteRepository;
        private readonly IMapper _mapper;

        public PosteService(IPosteRepository PosteRepository, IMapper mapper)
        {
            this._PosteRepository = PosteRepository;
            this._mapper = mapper;
        }

        public async Task<PosteDTO> AddPoste(PosteDTO Poste)
        {
            var returnedPoste = await this._PosteRepository.AddPoste(this._mapper.Map<Poste>(Poste));
            return this._mapper.Map<PosteDTO>(returnedPoste);
        }

        public async Task DeletePoste(int id)
        {
            await this._PosteRepository.DeletePoste(id);
        }

        public async Task<PosteDTO> GetPoste(int id)
        {
            return this._mapper.Map<PosteDTO>(await this._PosteRepository.GetPoste(id));
        }

        public async Task<IEnumerable<PosteDTO>> GetPostes()
        {
            //var query = this._PosteRepository.GetPostes().ProjectTo<PosteDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Poste>, PagedList<PosteDTO>>(collabs);
            //return await PagedList<PosteDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _PosteRepository.GetPostes();
            return _mapper.Map<IEnumerable<Poste>, IEnumerable<PosteDTO>>(result);
        }

        public async Task UpdatePoste(int id, PosteDTO Poste)
        {
            await this._PosteRepository.UpdatePoste(id, this._mapper.Map<Poste>(Poste));
        }
    }
}

