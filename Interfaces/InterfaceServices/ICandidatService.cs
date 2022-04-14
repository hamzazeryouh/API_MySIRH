﻿

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    public interface ICandidatService
    {
        Task<IEnumerable<CandidatDTO>> GetCandidats();
        Task<CandidatDTO> GetCandidat(int id);
        Task UpdateCandidat(int id, CandidatDTO Candidat);
        Task<CandidatDTO> AddCandidat(CandidatDTO Candidat);
        Task DeleteCandidat(int id);
    }
}