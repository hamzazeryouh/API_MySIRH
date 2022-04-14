using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface IPosteService
    {
        Task<IEnumerable<PosteDTO>> GetPostes();
        Task<PosteDTO> GetPoste(int id);
        Task UpdatePoste(int id, PosteDTO Poste);
        Task<PosteDTO> AddPoste(PosteDTO Poste);
        Task DeletePoste(int id);
    }
}
