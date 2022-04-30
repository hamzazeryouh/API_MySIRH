namespace API_MySIRH.
{

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
        IDataAccess<TEntity> DataAccess<TEntity,Tkey>()
            where TEntity : class;

        /// <summary>
        /// Returns the repository for the provided type.
        /// </summary>
        /// <typeparam name="TEntity">The database entity type.</typeparam>
        /// <typeparam name="TKey">The key entity type.</typeparam>
        /// <returns>Returns <see cref="DataAccess{TEntity}"/>.</returns>


     


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
}
