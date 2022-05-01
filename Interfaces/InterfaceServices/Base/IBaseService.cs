using API_MySIRH.DTOs;
using API_MySIRH.Helpers;

namespace API_MySIRH.Interfaces.InterfaceServices.Base
{
    /// <summary>
    /// an interface that every service should implement
    /// used for sharing common functionalities between all services 
    /// </summary>
    public interface IBaseService<TEntity,TKey, Model>
        where TEntity : class
    {
        /// <summary>
        /// get the list of all <see cref="TEntity"/>
        /// </summary>
        /// <returns>Client List</returns>

        Task<Result<IEnumerable<Model>>> GetAllAsync<TListFilterOption>(TListFilterOption filterOption) where TListFilterOption : ListFilterOption;

        /// <summary>
        /// return the list of <see cref="TEntity"/> as paged result
        /// </summary>
        /// <typeparam name="TFilter"></typeparam>
        /// <param name="filterOption"></param>
        /// <returns></returns>
        Task<PagedResult<Model>> GeAsPagedResultAsync<TFilter>(TFilter filterOption) where TFilter : FilterOption;

        /// <summary>
        /// get the <see cref="TEntity"/> with the  given id
        /// </summary>
        /// <param name="id">the id of the <see cref="TEntity"/> to retrieve</param>
        /// <returns>the <see cref="Model"/> result</returns>
        Task<Result<Model>> GetByIdAsync(TKey id);

        /// <summary>
        /// create <see cref="TEntity"/> with the given values
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        Task<Result<Model>> CreateAsync(Model createModel);

        /// <summary>
        /// update <see cref="TEntity"/> from the given model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        Task<Result<Model>> UpdateAsync(TKey TKey, Model updateModel);

        /// <summary>
        /// delete <see cref="TEntity"/> with the given id
        /// </summary>
        /// <param name="id">the id of the bank account to be deleted</param>
        /// <returns>a result instant</returns>
        Task<Result> DeleteAsync(TKey id);
    }
}
