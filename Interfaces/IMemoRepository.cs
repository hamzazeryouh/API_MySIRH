using API_MySIRH.Entities;

namespace API_MySIRH.Interfaces
{
    public interface IMemoRepository
    {
        Task<IEnumerable<Memo>> GetMemos();
        Task<Memo> GetMemo(int id);
        Task UpdateMemo(int id, Memo memo);
        Task<Memo> AddMemo(Memo memo);
        Task DeleteMemo(int id);
        bool MemoExists(int id);
    }
}
