using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Exceptions;
using API_MySIRH.Helpers;
using API_MySIRH.Interfaces;
using API_MySIRH.Interfaces.InterfaceServices.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API_MySIRH.Services
{
    public class BaseService
    {
    }




    /// <summary>
    /// the base interface for all DataServices
    /// </summary>
    public class BaseService<TEntity, TModel> : IBaseService<TEntity, TModel>
        where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _dataAccess;
        protected readonly IDataRequestBuilder<TEntity> _dataRequestBuilder;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly string _entityName = typeof(TEntity).Name;

        public BaseService(
           IDataRequestBuilder<TEntity> dataRequestBuilder,
           IUnitOfWork unitOfWork,
           IMapper mapper)
        {
            _dataAccess = unitOfWork.BaseRepository<TEntity>();
            _dataRequestBuilder = dataRequestBuilder;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Result<TModel>> CreateAsync(TModel createModel)
        {
            var entity = _mapper.Map<TEntity>(createModel);

            await BeforeAddEntity(entity, createModel);

            await _dataAccess.AddAsync(entity);

            await AfterAddEntity(entity, createModel);

            await _unitOfWork.SaveChangesAsync();

            await AfterSaveChangesAddEntity(entity, createModel);

            var data = _mapper.Map<TModel>(entity);

            return Result<TModel>.Success(data, $"{_entityName} added successfully");
        }

        public virtual async Task<Result> DeleteAsync(int id)
        {
            await BeforeDeleteEntity(id);
            var entity = await _dataAccess.DeleteAsync(id);
            await AfterDeleteEntity(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success($"{_entityName} removed successfully");
        }

        public async Task<PagedResult<TModel>> GeAsPagedResultAsync<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
        {
            var request = BuildAsPagedDataRequest(filterOption);
            var result = await _dataAccess.GetPagedResultAsync(filterOption, request, SkipSearchQuery());

            if (!result.HasValue)
                return PagedResult<TModel>.Failed(result.Error, $"Failed to retrieve list of {_entityName}");

            var data = _mapper.Map<IEnumerable<TModel>>(result.Value);
            return PagedResult<TModel>.Success(
                data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount,
                $"list of {_entityName} retrieved successfully");
        }


        public async Task<Result<IEnumerable<TModel>>> GetAllAsync<TListFilterOption>(TListFilterOption filterOption)
            where TListFilterOption : ListFilterOption
        {
            var request = BuildListDataRequest(filterOption);
            var result = await _dataAccess.GetAsync(request);

            if (result is null)
                return PagedResult<TModel>.Failed(null, $"Failed to retrieve list of {_entityName}");

            var data = _mapper.Map<IEnumerable<TModel>>(result);
            return Result<IEnumerable<TModel>>.Success(data);
        }

        public async Task<Result<TModel>> UpdateAsync(int id, TModel updateModel)
        {
            var entity = await GetEntityByIdAsync(id);

            await BeforeUpdateEntity(entity, updateModel);
            _dataAccess.Update(entity);

            await AfterUpdateEntity(entity, updateModel);

            await _unitOfWork.SaveChangesAsync();

            await AfterSaveChangesUpdateEntity(entity, updateModel);

            var data = _mapper.Map<TModel>(entity);
            return Result<TModel>.Success(data, $"{_entityName} updated successfully");
        }

        public async Task<Result<TModel>> GetByIdAsync(int id)
        {
            TEntity entity = await GetEntityByIdAsyncWithRelatedEntity(id);
            var data = _mapper.Map<TModel>(entity);
            await AfterGetByIdEntity(entity, data);
            return Result<TModel>.Success(data, $"the {_entityName} retrieved successfully");
        }

        #region virtual methods

        protected virtual Task BeforeAddEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task AfterAddEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task AfterSaveChangesAddEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task BeforeUpdateEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task AfterUpdateEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task AfterSaveChangesUpdateEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task AfterGetByIdEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task BeforeDeleteEntity(int id)
            => Task.CompletedTask;

        protected virtual Task AfterDeleteEntity(TEntity entity)
            => Task.CompletedTask;

        protected virtual bool SkipSearchQuery()
            => false;

        protected virtual Expression<Func<TEntity, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
            => PredicateBuilder.True<TEntity>();

        protected virtual Expression<Func<TEntity, bool>> BuildGetListPredicate()
           => PredicateBuilder.True<TEntity>();


        protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildIncludesList()
           => null;

        protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildIncludesGetById()
           => null;

        protected virtual Expression<Func<TEntity, bool>> BuildGetListPredicate<TListFilterOption>(TListFilterOption filterOption)
           where TListFilterOption : ListFilterOption
          => PredicateBuilder.True<TEntity>();

        #endregion

        #region privates 

        /// <summary>
        /// build get as paged data request form the given filter option
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>the data request</returns>
        protected IDataRequest<TEntity> BuildAsPagedDataRequest<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
            => _dataRequestBuilder.AddInclude(BuildIncludesList())
                .AddPredicate(BuildGetAsPagedPredicate(filterOption))
                .Buil();

        /// <summary>
        /// build get list data request
        /// </summary>
        /// <returns>the data request</returns>
        /// 
        private IDataRequest<TEntity> BuildListDataRequest<TListFilterOption>(TListFilterOption filterOption) where TListFilterOption : ListFilterOption
            => _dataRequestBuilder
                .AddPredicate(BuildGetListPredicate(filterOption))
                .AddInclude(BuildIncludesList())
                .Buil();


        private IDataRequest<TEntity> BuildIncludeGetById()
        {
            return _dataRequestBuilder.AddInclude(BuildIncludesGetById()).Buil();
        }

        #endregion

        #region protected

        protected async Task<TEntity> GetEntityByIdAsyncWithRelatedEntity(int id)
        {
            var request = BuildIncludeGetById();
            var entity = await _dataAccess.GetAsync(id, request);

            if (entity is null)
                throw new NotFoundException($"there is not {_entityName} with given {id}");

            return entity;
        }

        protected async Task<TEntity> GetEntityByIdAsync(int id)
        {
            var entity = await _dataAccess.GetAsync(id);

            if (entity is null)
                throw new NotFoundException($"there is not {_entityName} with given {id}");

            return entity;
        }

        #endregion

    }
}
