using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class PosteRepository : IPosteRepository
    {
        private readonly DataContext _context;


        public PosteRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Poste> AddPoste(Poste Poste)
        {
            await this._context.Postes.AddAsync(Poste);
            await this._context.SaveChangesAsync();
            return Poste;
        }

        public async Task<bool> PosteExists(int id)
        {
            return await this._context.Postes.AnyAsync(Poste => Poste.Id == id);
        }

        public async Task DeletePoste(int id)
        {
            var PosteToDelete = await this._context.Postes.FindAsync(id);
            if (PosteToDelete is not null)
                this._context.Postes.Remove(PosteToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Poste>> GetPostes()
        {
            return await this._context.Postes.ToListAsync();
        }

        public async Task<Poste> GetPoste(int id)
        {
            return  await _context.Postes.FindAsync(id);
        }

        public async Task UpdatePoste(int id, Poste Poste)
        {
            this._context.Entry(Poste).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }


}
