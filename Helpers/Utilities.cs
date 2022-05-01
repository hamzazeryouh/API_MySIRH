

namespace API_MySIRH.Helpers
{
    using API_MySIRH.Data;
    using API_MySIRH.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    /// <summary>
    /// Utilities class
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Get the result as an IEnumerable
        /// </summary>
        /// <typeparam name="TEntity">the type of the entity</typeparam>
        /// <param name="query">the IQueryable to be executed</param>
        /// <returns>IEnumerable</returns>
        public static async Task<IEnumerable<TEntity>> ToIEnumerableAsync<TEntity>(this IQueryable<TEntity> query)
            => await query.ToListAsync();

        /// <summary>
        /// return the query as a Paged Result
        /// </summary>
        /// <typeparam name="T">the type of the result</typeparam>
        /// <param name="query">the query to execute</param>
        /// <param name="page">the page number</param>
        /// <param name="pageSize">the page size</param>
        /// <returns>the result as a Paged Result</returns>
        public static async Task<PagedResult<T>> AsPagedResultAsync<T>(this IQueryable<T> query, int page, int pageSize)
            where T : class
        {
            try
            {
                page = page <= 0 ? 1 : page;
                pageSize = pageSize < 0 ? 1 : pageSize;

                var rowsCount = await query.CountAsync();
                var pageCount = (int)Math.Ceiling((double)rowsCount / pageSize);
                page = pageCount > 0 && page > pageCount ? pageCount : page;
                var skip = (page - 1) * pageSize;
                var queryResult = await query.Skip(skip).Take(pageSize).ToListAsync();

                return PagedResult<T>.Success(queryResult, page, pageCount, pageSize, rowsCount, "Result retrieved Successfully");
            }
            catch (Exception ex)
            {
                return PagedResult<T>.Failed(ex, "failed retrieving the result");
            }
        }

        /// <summary>
        /// get the IQueryable of entities filtered by the DataRequest
        /// </summary>
        /// <returns>IQueryable of entities</returns>
        /// <exception cref="ArgumentNullException">if the data request is null</exception>
        internal static IQueryable<TEntity> GetWithDataRequest<TEntity>
            (this IQueryable<TEntity> source, IDataRequest<TEntity> request)
                where TEntity : class
        {
            if (request is null)
                return source;

            if (request.Includes != null)
                source = request.Includes(source);


            if (request.Predicate != null)
                source = source.Where(request.Predicate);

            if (request.OrderByKeySelector != null)
                source = source.OrderBy(request.OrderByKeySelector);

            if (request.OrderByDescKeySelector != null)
                source = source.OrderByDescending(request.OrderByDescKeySelector);

            return source;
        }

        /// <summary>
        /// get the IQueryable of entities filtered by the DataRequest
        /// </summary>
        /// <returns>IQueryable of entities</returns>
        /// <exception cref="ArgumentNullException">if the request is null or 
        /// the Selector is null</exception>
        internal static IQueryable<TOut> GetWithDataRequest<TEntity, TOut>
            (this IQueryable<TEntity> source, IDataRequest<TEntity, TOut> request)
                where TEntity : class
        {
            IQueryable<TEntity> items = source
                .GetWithDataRequest(request as IDataRequest<TEntity>);

            if (request.Selector != null)
                throw new ArgumentNullException("you have to specify the selector, or use the other method that doesn't require a TOut");

            return items.Select(request.Selector);
        }

        /// <summary>
        /// build the OrderBy Query dynamically
        /// </summary>
        /// <typeparam name="T">the type of entity we building the orderBy for it</typeparam>
        /// <param name="query">the query it self</param>
        /// <param name="sortColumn">the column you are soring with it</param>
        /// <param name="SortDirection">is the sorting direction</param>
        /// <returns>the query</returns>
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortColumn, SortDirection SortDirection)
        {
            // Dynamically creates a call like this: query.OrderBy(p => p.SortColumn)
            var parameter = Expression.Parameter(typeof(T), "p");

            var command = SortDirection == SortDirection.Asc ? "OrderBy" : "OrderByDescending";

            var objType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor property = default;
            foreach (var fieldNameProperty in sortColumn?.Split('.'))
            {
                if (property != null)
                    property = property.GetChildProperties().Find(fieldNameProperty, true);
                else
                    property = properties.Find(fieldNameProperty, true);
            }

            MemberExpression propertyAccess;
            if (property is null)
            {
                property = properties.Find("Id", true);
                // this is the part p.SortColumn
                propertyAccess = GetMemberExpression<T>(parameter, "Id");
            }
            else
                // this is the part p.SortColumn
                propertyAccess = GetMemberExpression<T>(parameter, sortColumn);

            // this is the part p => p.SortColumn
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // finally, call the "OrderBy" / "OrderByDescending" method with the order by lambda expression
            Expression resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { objType, property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }


        #region private methods

        /// <summary>
        /// get member expression
        /// </summary>
        /// <typeparam name="T">the type to be used</typeparam>
        /// <param name="parameter">the parameter of lambda expression</param>
        /// <param name="propName">the property name</param>
        /// <returns>a member expression</returns>
        private static MemberExpression GetMemberExpression<T>(ParameterExpression parameter, string propName)
        {
            if (string.IsNullOrEmpty(propName)) return null;

            var memberExpression = default(MemberExpression);
            var propertiesName = propName.Split('.');

            foreach (var item in propertiesName)
            {
                if (memberExpression is null)
                    memberExpression = Expression.Property(parameter, item);
                else
                    memberExpression = Expression.Property(memberExpression, item);
            }

            return memberExpression;
        }

        #endregion
    }
}
