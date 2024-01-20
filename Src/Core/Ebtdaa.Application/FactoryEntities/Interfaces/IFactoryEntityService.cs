using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryEntities.Dtos;

namespace Ebtdaa.Application.FactoryEntities.Interfaces
{
    public interface IFactoryEntityService
    {
        Task<BaseResponse<List<FactoryEntityResultDto>>> GetAll();
    }
}
