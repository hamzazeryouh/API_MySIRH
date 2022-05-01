using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Services.EvaluationService;
using AutoMapper;

namespace API_MySIRH.Services.TemplateService
{
    public class TemplateService : BaseService<Template, int, TemplateDTO>, ITemplateService
    {
        public TemplateService(IDataRequestBuilder<Template> dataRequestBuilder, IUnitOfWork unitOfWork, IMapper mapper)
            : base(dataRequestBuilder, unitOfWork, mapper)
        {
        }
    }
}
