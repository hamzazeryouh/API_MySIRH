using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class TypeContratService: ITypeContratService
    {

        private readonly ITypeContratRepository _TypeContratRepository;
        private readonly IMapper _mapper;

        public TypeContratService(ITypeContratRepository TypeContratRepository, IMapper mapper)
        {
            this._TypeContratRepository = TypeContratRepository;
            this._mapper = mapper;
        }

        public async Task<TypeContratDTO> AddTypeContrat(TypeContratDTO TypeContrat)
        {
            var returnedTypeContrat = await this._TypeContratRepository.AddTypeContrat(this._mapper.Map<TypeContrat>(TypeContrat));
            return this._mapper.Map<TypeContratDTO>(returnedTypeContrat);
        }

        public async Task DeleteTypeContrat(int id)
        {
            await this._TypeContratRepository.DeleteTypeContrat(id);
        }

        public async Task<TypeContratDTO> GetTypeContrat(int id)
        {
            return this._mapper.Map<TypeContratDTO>(await this._TypeContratRepository.GetTypeContrat(id));
        }

        public async Task<IEnumerable<TypeContratDTO>> GetTypeContrats()
        {
            //var query = this._TypeContratRepository.GetTypeContrats().ProjectTo<TypeContratDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<TypeContrat>, PagedList<TypeContratDTO>>(collabs);
            //return await PagedList<TypeContratDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _TypeContratRepository.GetTypeContrats();
            return _mapper.Map<IEnumerable<TypeContrat>, IEnumerable<TypeContratDTO>>(result);
        }

        public async Task UpdateTypeContrat(int id, TypeContratDTO TypeContrat)
        {
            await this._TypeContratRepository.UpdateTypeContrat(id, this._mapper.Map<TypeContrat>(TypeContrat));
        }
    }
}
