using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.ScreenUpdateStatus.Interfaces
{
    public interface IScreenStatusService
    {
        Task<BaseResponse<ScreenStatusResultDto>> GetAll( int periodId , int factoryId);
    }
}
