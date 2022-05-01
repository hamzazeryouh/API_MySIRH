using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using AutoMapper;

namespace API_MySIRH.Services.EvaluationService
{
    public class EvaluationService : BaseService<Evaluation, int, EvaluationDTO>, IEvaluationService
    {
        public EvaluationService(IDataRequestBuilder<Evaluation> dataRequestBuilder, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(dataRequestBuilder, unitOfWork, mapper)
        {
        }
    }
}
