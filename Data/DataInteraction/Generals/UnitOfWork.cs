


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
    using API_MySIRH.Repositories.Evaluation;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        private Hashtable _repositories;
        private Hashtable _repositoriesWithKey;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="loggerFactory"></param>
        public UnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IBaseRepository<TEntity> IUnitOfWork.BaseRepository<TEntity>()
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
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IBaseRepository<TEntity, TKey> IUnitOfWork.BaseRepository<TEntity, TKey>()
        {
            if (_repositoriesWithKey == null)
            {
                _repositoriesWithKey = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositoriesWithKey.ContainsKey(type))
            {

                object repositoryInstance = Tools.CreateInstantOf<BaseRepository<TEntity, TKey>>(
                    new Type[] { typeof(DataContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                _repositoriesWithKey.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity, TKey>)_repositoriesWithKey[type];
        }

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

         IEvaluationRepository _evaluationRepository ;
        public IEvaluationRepository EvaluationRepository
        {


            get
            {
               if(_evaluationRepository is null)

                    _evaluationRepository = new EvaluationRepository(_dbContext, _loggerFactory);

               return (_evaluationRepository);
                
            }
        }



        ICommenterRepository _commenterRepository;

        public ICommenterRepository CommenterRepository
        {


            get
            {
                if (_commenterRepository is null)

                    _commenterRepository = new CommenterRepository(_dbContext, _loggerFactory);

                return (_commenterRepository);

            }
        }

        ITemplateRepository templateRepository;

        public ITemplateRepository TemplateRepository
        {


            get
            {
                if (templateRepository is null)

                    templateRepository = new TemplateRepository(_dbContext, _loggerFactory);

                return (templateRepository);

            }
        }



        /// <summary>
        /// ExecuteSqlCommand
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

    }
}
