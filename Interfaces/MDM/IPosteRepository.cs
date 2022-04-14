using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface IPosteRepository
    {
        Task<IEnumerable<Poste>> GetPostes();
        Task<Poste> GetPoste(int id);
        Task UpdatePoste(int id, Poste Poste);
        Task<Poste> AddPoste(Poste Poste);
        Task DeletePoste(int id);
        Task<bool> PosteExists(int id);
    }
}
