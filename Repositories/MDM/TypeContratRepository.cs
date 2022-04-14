using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class TypeContratRepository : ITypeContratRepository
    {
        private readonly DataContext _context;


        public TypeContratRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<TypeContrat> AddTypeContrat(TypeContrat TypeContrat)
        {
            await this._context.TypeContrats.AddAsync(TypeContrat);
            await this._context.SaveChangesAsync();
            return TypeContrat;
        }

        public async Task<bool> TypeContratExists(int id)
        {
            return await this._context.TypeContrats.AnyAsync(TypeContrat => TypeContrat.Id == id);
        }

        public async Task DeleteTypeContrat(int id)
        {
            var TypeContratToDelete = await this._context.TypeContrats.FindAsync(id);
            if (TypeContratToDelete is not null)
                this._context.TypeContrats.Remove(TypeContratToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypeContrat>> GetTypeContrats()
        {
            return await this._context.TypeContrats.ToListAsync();
        }

        public async Task<TypeContrat> GetTypeContrat(int id)
        {
            return  await _context.TypeContrats.FindAsync(id);
        }

        public async Task UpdateTypeContrat(int id, TypeContrat TypeContrat)
        {
            this._context.Entry(TypeContrat).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }


}
