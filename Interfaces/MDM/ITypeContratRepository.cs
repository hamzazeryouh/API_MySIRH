using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ITypeContratRepository
    {
        Task<IEnumerable<TypeContrat>> GetTypeContrats();
        Task<TypeContrat> GetTypeContrat(int id);
        Task UpdateTypeContrat(int id, TypeContrat TypeContrat);
        Task<TypeContrat> AddTypeContrat(TypeContrat TypeContrat);
        Task DeleteTypeContrat(int id);
        Task<bool> TypeContratExists(int id);
    }
}
