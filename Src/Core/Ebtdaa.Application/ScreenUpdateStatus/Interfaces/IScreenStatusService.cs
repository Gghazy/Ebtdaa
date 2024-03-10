using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.ScreenUpdateStatus.Interfaces
{
    public interface IScreenStatusService
    {
        Task<BaseResponse<ScreenStatusResultDto>> GetAll( int periodId , int factoryId);
        Task<BaseResponse<ScreenStatusResultDto>> AddAsync(ScreenStatusRequestDto req);
        Task<BaseResponse<ScreenStatusResultDto>> UpdateAsync(ScreenStatusRequestDto req);
        Task<BaseResponse<ScreenStatusResultDto>> ReverseApproval(ScreenStatusRequestDto req);
        Task CheckBasicInfoScreenStatus(int periodId, int factoryId);
        Task CheckMonthlyFactoryFinanicailScreenStatus(int factoryId, int periodId);
        Task CheckFactoryFinanicailScreenStatus(int factoryId);
        Task CheckFactoryLocationScreenStatus(int factoryId);
        Task CheckFactoryContactScreenStatus(int factoryId);
        Task CheckFactoryProductScreenStatus(int factoryId, int periodId);
        Task CheckActualProductionScreenStatus(int? factoryId, int periodId, FactoryStatusEnum? status);
    }
}
