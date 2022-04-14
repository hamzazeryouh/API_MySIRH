using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class CollaborateurService : ICollaborateurService
    {
        private readonly ICollaborateurRepository _collaborateurRepository;
        private readonly IMapper _mapper;

        public CollaborateurService(ICollaborateurRepository collaborateurRepository, IMapper mapper)
        {
            this._collaborateurRepository = collaborateurRepository;
            this._mapper = mapper;
        }

        public async Task<CollaborateurDTO> AddCollaborateur(CollaborateurDTO collaborateur)
        {
            var returnedCollaborateur = await this._collaborateurRepository.AddCollaborateur(this._mapper.Map<Collaborateur>(collaborateur));
            return this._mapper.Map<CollaborateurDTO>(returnedCollaborateur);
        }

        public async Task DeleteCollaborateur(int id)
        {
            await this._collaborateurRepository.DeleteCollaborateur(id);
        }

        public async Task<CollaborateurDTO> GetCollaborateur(int id)
        {
            return this._mapper.Map<CollaborateurDTO>(await this._collaborateurRepository.GetCollaborateur(id));
        }

        public async Task<IEnumerable<CollaborateurDTO>> GetCollaborateurs()
        {
            //var query = this._collaborateurRepository.GetCollaborateurs().ProjectTo<CollaborateurDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Collaborateur>, PagedList<CollaborateurDTO>>(collabs);
            //return await PagedList<CollaborateurDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _collaborateurRepository.GetCollaborateurs(); 
            return _mapper.Map<IEnumerable<Collaborateur>, IEnumerable<CollaborateurDTO>>(result);
        }

        public async Task UpdateCollaborateur(int id, CollaborateurDTO collaborateur)
        {
            await this._collaborateurRepository.UpdateCollaborateur(id, this._mapper.Map<Collaborateur>(collaborateur));
        }
    }
}
