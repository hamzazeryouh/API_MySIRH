

using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Data
{
    /// <summary>
    /// represent a data Source in case of entity framework this will be a DbContext
    /// </summary>
    public interface IDataSource : IDisposable
    {
        #region DbSets, here we define all the Entities DbSets

        public DbSet<ToDoItem> ToDoItems { get; set; } 
        public DbSet<ToDoList> ToDoLists { get; set; } 
        public DbSet<Memo> Memos { get; set; } 
        public DbSet<PosteNiveau> Niveaux { get; set; } 
        public DbSet<Civilite> Civilites { get; set; }
        public DbSet<Poste> Postes { get; set; }
        public DbSet<Site> Sites { get; set; } 
        public DbSet<SkillCenter> SkillCenters { get; set; } 
        public DbSet<Collaborateur> Collaborateurs { get; set; } 
        public DbSet<Candidat> Candidats { get; set; } 
        public DbSet<TypeContrat> TypeContrats { get; set; } 



        #endregion

        /// <summary>
        /// get the DbSet of the given entity
        /// </summary>
        /// <typeparam name="TEntity">the entity type</typeparam>
        /// <returns>a DbSet</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// save the changes to data source
        /// </summary>
        /// <returns>affected lines</returns>
        int SaveChanges();

        /// <summary>
        /// save the changes to data source
        /// </summary>
        /// <param name="cancellationToken">cancellation Token</param>
        /// <returns>affected lines</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}