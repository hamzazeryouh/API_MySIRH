using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class MemoRepository : IMemoRepository
    {
        private readonly DataContext _context;
        public MemoRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Memo> AddMemo(Memo memo)
        {
            _context.Memos.Add(memo);
            await _context.SaveChangesAsync();
            return memo;
        }
        public async Task DeleteMemo(int id)
        {
            var memo = await _context.Memos.FindAsync(id);
            if (memo != null)
            {
                _context.Memos.Remove(memo);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Memo> GetMemo(int id)
        {
            var memo = await _context.Memos.FindAsync(id);
            return memo;

        }
        public async Task<IEnumerable<Memo>> GetMemos()
        {
            return await _context.Memos.ToListAsync();
        }
        public bool MemoExists(int id)
        {
            return _context.Memos.Any(e => e.Id == id);
        }
        public async Task UpdateMemo(int id, Memo memo)
        {
            if (id == memo.Id)
            {
                _context.Entry(memo).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

        }
    }
}
