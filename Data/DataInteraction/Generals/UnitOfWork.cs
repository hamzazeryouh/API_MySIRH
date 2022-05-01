


namespace API_MySIRH.Presistence
{

    using System.Collections;
    using System.Linq;
    using System.Threading.Tasks;
    using API_MySIRH.Data;
    using API_MySIRH.Helpers;
    using API_MySIRH.Interfaces;
    using API_MySIRH.Repositories;
    using API_MySIRH.Repositories.BaseRepository;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        private Hashtable _repositories;
        private Hashtable _repositoriesWithKey;



        private readonly ILoggerFactory _loggerFactory;
        public ICandidatRepository _CandidatRepository;
        public ICandidatRepository CandidatRepository {


            get
            {
                if (_CandidatRepository is null)
                    _CandidatRepository = new CandidatRepository(_dbContext, _loggerFactory);

                return _CandidatRepository;
            }
                  } 

        public UnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;

        }

        public IBaseRepository<TEntity> BaseRepository<TEntity, Tkey>()
            where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                object repositoryInstance = Tools.CreateInstantOf<BaseRepository<TEntity>>(
                    new Type[] { typeof(DataContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type];
        }


        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

    }
}
