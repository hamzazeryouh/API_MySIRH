using API_MySIRH.Data;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories.MDM
{
    public class PosteNiveauRepository: IPosteNiveauRepository
    {
        private readonly DataContext _context;


        public PosteNiveauRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<PosteNiveau> AddPosteNiveau(PosteNiveau PosteNiveau)
        {
            await this._context.Niveaux.AddAsync(PosteNiveau);
            await this._context.SaveChangesAsync();
            return PosteNiveau;
        }

        public async Task<bool> PosteNiveauExists(int id)
        {
            return await this._context.Niveaux.AnyAsync(PosteNiveau => PosteNiveau.Id == id);
        }

        public async Task DeletePosteNiveau(int id)
        {
            var PosteNiveauToDelete = await this._context.Niveaux.FindAsync(id);
            if (PosteNiveauToDelete is not null)
                this._context.Niveaux.Remove(PosteNiveauToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PosteNiveau>> GetPosteNiveaus()
        {
            return await this._context.Niveaux.ToListAsync();
        }

        public async Task<PosteNiveau> GetPosteNiveau(int id)
        {
            return await _context.Niveaux.FindAsync(id);
        }

        public async Task UpdatePosteNiveau(int id, PosteNiveau PosteNiveau)
        {
            this._context.Entry(PosteNiveau).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }
}

