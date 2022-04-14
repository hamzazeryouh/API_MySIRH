using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class CollaborateurRepository : ICollaborateurRepository
    {
        private readonly DataContext _context;


        public CollaborateurRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Collaborateur> AddCollaborateur(Collaborateur collaborateur)
        {
            await this._context.Collaborateurs.AddAsync(collaborateur);
            await this._context.SaveChangesAsync();
            return collaborateur;
        }

        public async Task<bool> CollaborateurExists(int id)
        {
            return await this._context.Collaborateurs.AnyAsync(collaborateur => collaborateur.Id == id);
        }

        public async Task DeleteCollaborateur(int id)
        {
            var collaborateurToDelete = await this._context.Collaborateurs.FindAsync(id);
            if (collaborateurToDelete is not null)
                this._context.Collaborateurs.Remove(collaborateurToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Collaborateur>> GetCollaborateurs()
        {
            return await this._context.Collaborateurs.ToListAsync();
        }

        public async Task<Collaborateur> GetCollaborateur(int id)
        {
            return await this._context.Collaborateurs.FindAsync(id);
        }

        public async Task UpdateCollaborateur(int id, Collaborateur collaborateur)
        {
            this._context.Entry(collaborateur).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }
}
