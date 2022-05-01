using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using API_MySIRH.Repositories.BaseRepository;

namespace API_MySIRH.Repositories.Evaluation
{
    public class CommenterRepository : BaseRepository<Commenter>, ICommenterRepository
    {
        public CommenterRepository(IDataSource context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
