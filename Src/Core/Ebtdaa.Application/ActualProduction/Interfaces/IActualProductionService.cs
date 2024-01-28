using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ActualProduction.Interfaces
{
    public interface IActualProductionService
    {

        Task<BaseResponse<QueryResult<ProductCapacityResultDto>>> GetAll(ActualProductionSearch search);
        Task<BaseResponse<ActualProductionResultDto>> AddAsync(ActualProductionRequestDto result);
        Task<BaseResponse<ActualProductionResultDto>>UpdateAsync(ActualProductionRequestDto result);
        Task<BaseResponse<ActualProductionResultDto>> GetOne (int id);
    }
}
