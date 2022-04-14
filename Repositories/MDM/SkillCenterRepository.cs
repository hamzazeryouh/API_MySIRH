using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class SkillCenterRepository : ISkillCenterRepository
    {
        private readonly DataContext _context;


        public SkillCenterRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<SkillCenter> AddSkillCenter(SkillCenter SkillCenter)
        {
            await this._context.SkillCenters.AddAsync(SkillCenter);
            await this._context.SaveChangesAsync();
            return SkillCenter;
        }

        public async Task<bool> SkillCenterExists(int id)
        {
            return await this._context.SkillCenters.AnyAsync(SkillCenter => SkillCenter.Id == id);
        }

        public async Task DeleteSkillCenter(int id)
        {
            var SkillCenterToDelete = await this._context.SkillCenters.FindAsync(id);
            if (SkillCenterToDelete is not null)
                this._context.SkillCenters.Remove(SkillCenterToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SkillCenter>> GetSkillCenters()
        {
            return await this._context.SkillCenters.ToListAsync();
        }

        public async Task<SkillCenter> GetSkillCenter(int id)
        {
            return  await _context.SkillCenters.FindAsync(id);
        }

        public async Task UpdateSkillCenter(int id, SkillCenter SkillCenter)
        {
            this._context.Entry(SkillCenter).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }


}
