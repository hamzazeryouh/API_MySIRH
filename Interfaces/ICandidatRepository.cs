using API_MySIRH.Entities;

namespace API_MySIRH.Interfaces
{
    public interface ICandidatRepository
    {
        Task<IEnumerable<Candidat>> GetCandidats();
        Task<Candidat> GetCandidat(int id);
        Task UpdateCandidat(int id, Candidat Candidat);
        Task<Candidat> AddCandidat(Candidat Candidat);
        Task DeleteCandidat(int id);
        Task<bool> CandidatExists(int id);
    }
}
