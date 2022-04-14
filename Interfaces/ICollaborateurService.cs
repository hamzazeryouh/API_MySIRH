using API_MySIRH.DTOs;

namespace API_MySIRH.Interfaces
{
    public interface ICollaborateurService
    {
        Task<IEnumerable<CollaborateurDTO>> GetCollaborateurs();
        Task<CollaborateurDTO> GetCollaborateur(int id);
        Task UpdateCollaborateur(int id, CollaborateurDTO collaborateur);
        Task<CollaborateurDTO> AddCollaborateur(CollaborateurDTO collaborateur);
        Task DeleteCollaborateur(int id);
    }
}
