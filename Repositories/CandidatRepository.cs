using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class CandidatRepository : ICandidatRepository
    {
        private readonly DataContext _context;


        public CandidatRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Candidat> AddCandidat(Candidat Candidat)
        {
            await this._context.Candidats.AddAsync(Candidat);
            await this._context.SaveChangesAsync();
            return Candidat;
        }

        public async Task<bool> CandidatExists(int id)
        {
            return await this._context.Candidats.AnyAsync(Candidat => Candidat.Id == id);
        }

        public async Task DeleteCandidat(int id)
        {
            var CandidatToDelete = await this._context.Candidats.FindAsync(id);
            if (CandidatToDelete is not null)
                this._context.Candidats.Remove(CandidatToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidat>> GetCandidats()
        {
            return await this._context.Candidats.ToListAsync();
        }

        public async Task<Candidat> GetCandidat(int id)
        {
            return  await _context.Candidats.FindAsync(id);
        }

        public async Task UpdateCandidat(int id, Candidat Candidat)
        {
            this._context.Entry(Candidat).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }


}
