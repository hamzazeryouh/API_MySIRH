using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ITypeContratService
    {
        Task<IEnumerable<TypeContratDTO>> GetTypeContrats();
        Task<TypeContratDTO> GetTypeContrat(int id);
        Task UpdateTypeContrat(int id, TypeContratDTO TypeContrat);
        Task<TypeContratDTO> AddTypeContrat(TypeContratDTO TypeContrat);
        Task DeleteTypeContrat(int id);
    }
}
