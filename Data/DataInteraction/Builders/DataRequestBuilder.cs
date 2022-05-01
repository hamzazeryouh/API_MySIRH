
using API_MySIRH.Enums;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace API_MySIRH.Data
{
    /// <summary>
    /// an implementation of <see cref="IDataRequestBuilder"/>
    /// </summary>
    /// <typeparam name="TEntity">the entity we building the data request for</typeparam>
    public class DataRequestBuilder<TEntity> : IDataRequestBuilder<TEntity>
        where TEntity : class
    {
        protected string Query;
        protected Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes;
        protected Expression<Func<TEntity, bool>> Predicate;
        protected Expression<Func<TEntity, object>> OrderByKeySelector;
        protected Expression<Func<TEntity, object>> OrderByDescKeySelector;

        /// <summary>
        /// the default constructor
        /// </summary>
        public DataRequestBuilder()
        { }

        /// <summary>
        /// add the search query
        /// </summary>
        /// <param name="query">the search query</param>
        /// <returns>the builder</returns>
        public IDataRequestBuilder<TEntity> AddQuery(string query)
        {
            Query = query;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns>the builder</returns>
        public IDataRequestBuilder<TEntity> AddInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            Includes = includes;
            return this;
        }

        /// <summary>
        /// add the predicate query
        /// </summary>
        /// <param name="predicate">the predicate value</param>
        /// <returns>the builder</returns>
        public IDataRequestBuilder<TEntity> AddPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
            return this;
        }

        /// <summary>
        /// add the orderBy query
        /// </summary>
        /// <param name="orderByKeySelector">orderBy selector</param>
        /// <returns>the builder</returns>
        public IDataRequestBuilder<TEntity> AddOrderBy(SortDirection orderBy, Expression<Func<TEntity, object>> orderByKeySelector)
        {
            switch (orderBy)
            {
                case SortDirection.Desc:
                    OrderByDescKeySelector = orderByKeySelector;
                    break;
                case SortDirection.Asc:
                    OrderByKeySelector = orderByKeySelector;
                    break;
            }

            return this;
        }

        /// <summary>
        /// build and return the IDataRequest instant
        /// </summary>
        /// <returns>IDataRequest instant</returns>
        /// 

        public virtual DataRequest<TEntity> Buil()
        {
            var dataRequestInstant = new DataRequest<TEntity>
            {
                Query = Query,
                Includes = Includes,
                Predicate = Predicate,
                OrderByKeySelector = OrderByKeySelector,
                OrderByDescKeySelector = OrderByDescKeySelector
            };

            EmptyFields();
            return dataRequestInstant;
        }


        /// <summary>
        /// clear the values of the fields
        /// </summary>
        protected virtual void EmptyFields()
        {
            Query = null;
            Includes = null;
            Predicate = null;
            OrderByKeySelector = null;
            OrderByDescKeySelector = null;
        }

    }
}
