using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using API_MySIRH.Repositories.BaseRepository;

namespace API_MySIRH
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(IDataSource context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
