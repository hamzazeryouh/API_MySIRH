using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces.InterfaceServices.Base;

namespace API_MySIRH.Services.EvaluationService
{
    public interface IEvaluationService : IBaseService<Evaluation, int, EvaluationDTO>
    {
    }
}
