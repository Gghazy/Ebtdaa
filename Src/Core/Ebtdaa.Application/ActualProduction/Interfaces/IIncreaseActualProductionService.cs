using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.ActualProduction.Interfaces
{
    public interface IIncreaseActualProductionService
    {
        Task<BaseResponse<IncreaseActualProductionResultDto>> GetOne(MonthsEnum month, int factoryId);
        Task<BaseResponse<IncreaseActualProductionResultDto>> AddAsync(IncreaseActualProductionRequestDto result);
        Task<BaseResponse<IncreaseActualProductionResultDto>> UpdateAsync(IncreaseActualProductionRequestDto result);

    }
}
