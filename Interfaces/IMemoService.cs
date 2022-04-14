using API_MySIRH.DTOs;

namespace API_MySIRH.Interfaces
{
    public interface IMemoService
    {
        Task<IEnumerable<MemoDTO>> GetMemos();
        Task<MemoDTO> GetMemo(int id);
        Task UpdateMemo(int id, MemoDTO memoDTO);
        Task<MemoDTO> AddMemo(MemoDTO memoDTO);
        Task DeleteMemo(int id);
    }
}
