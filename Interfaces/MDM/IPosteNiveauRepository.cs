using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface IPosteNiveauRepository
    {
        Task<IEnumerable<PosteNiveau>> GetPosteNiveaus();
        Task<PosteNiveau> GetPosteNiveau(int id);
        Task UpdatePosteNiveau(int id, PosteNiveau PosteNiveau);
        Task<PosteNiveau> AddPosteNiveau(PosteNiveau PosteNiveau);
        Task DeletePosteNiveau(int id);
        Task<bool> PosteNiveauExists(int id);
    }
}
