using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using AutoMapper;

namespace API_MySIRH.Services.CommenterService
{
    public class CommenterService : BaseService<Commenter, int, CommenterDTO>, ICommenterService
    {
        public CommenterService(
            IDataRequestBuilder<Commenter> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(dataRequestBuilder, unitOfWork, mapper)
        {
        }
    }
}
