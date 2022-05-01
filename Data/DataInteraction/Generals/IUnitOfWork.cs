namespace API_MySIRH.Data;

using API_MySIRH.Interfaces;
using System.Threading.Tasks;

/// <summary>
/// Contains all the UnitOfWork methods.
/// </summary>Data
public interface IUnitOfWork
{

    /// <summary>
    /// Returns the repository for the provided type.
    /// </summary>
    /// <typeparam name="TEntity">The database entity type.</typeparam>
    /// <returns>Returns <see cref="DataAccess{TEntity}"/>.</returns>
    IBaseRepository<TEntity> BaseRepository<TEntity>()
        where TEntity : class, IEntity;

    /// <summary>
    /// Returns the repository for the provided type.
    /// </summary>
    /// <typeparam name="TEntity">The database entity type.</typeparam>
    /// <typeparam name="TKey">The key entity type.</typeparam>
    /// <returns>Returns <see cref="DataAccess{TEntity}"/>.</returns>
    IBaseRepository<TEntity, TKey> BaseRepository<TEntity, TKey>()
        where TEntity : class, IEntity<TKey>;


    ICandidatRepository CandidatRepository { get;  }

    IEvaluationRepository EvaluationRepository{ get; }

    ICommenterRepository CommenterRepository { get; }
    ITemplateRepository TemplateRepository { get; }



    /// <summary>
    /// Execute raw sql command against the configured database.
    /// </summary>
    /// <param name = "sql" > The sql string.</param>
    /// <param name = "parameters" > The paramters in the sql string.</param>
    /// <returns>Returns<see cref="int"/>.</returns>
    int ExecuteSqlCommand(string sql, params object[] parameters);

    /// <summary>
    /// Execute raw sql command against the configured database asynchronously.
    /// </summary>
    /// <param name="sql">The sql string.</param>
    /// <param name="parameters">The paramters in the sql string.</param>
    /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
    Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

    /// <summary>
    /// Reset the DbContext state by removing all the tracked and attached entities.
    /// </summary>
    void ResetContextState();

    /// <summary>
    /// Trigger the execution of the EF core commands against the configuired database.
    /// </summary>
    /// <returns>Returns <see cref="Task"/>.</returns>
    Task SaveChangesAsync();
}
