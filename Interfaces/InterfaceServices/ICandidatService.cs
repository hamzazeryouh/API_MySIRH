

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface ICandidatService
    {
        Task<IEnumerable<CandidatDTO>> GetCandidats();
        Task<CandidatDTO> GetCandidat(int id);
        Task UpdateCandidat(int id, CandidatDTO Candidat);
        Task<CandidatDTO> AddCandidat(CandidatDTO Candidat);
        Task DeleteCandidat(int id);

        Task<FileStreamResult> ExportExcel();

        Task<IEnumerable<CandidatDTO>> ImportExcel(IFormFile Excel);

        Task<CandidatDTO> Upload(IFormFile Image,int id,bool cv);

        Task<FileStreamResult> GetFile (string UniqueName);

    }
}
