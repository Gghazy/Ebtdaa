using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectorScreenStatus.Dtos;

namespace Ebtdaa.Application.InspectorScreenStatus.Interfaces
{
    public interface IInspectorScreenStatusService
    {
        Task<BaseResponse<InspectorScreenStatusResultDto>> GetAll(int periodId, int factoryId);

    }
}
