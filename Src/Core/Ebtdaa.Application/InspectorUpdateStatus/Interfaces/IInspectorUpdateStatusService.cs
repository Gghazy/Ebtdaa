using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectorUpdateStatus.Dtos;

namespace Ebtdaa.Application.InspectorUpdateStatus.Interfaces
{
    public interface IInspectorUpdateStatusService
    {
        Task<BaseResponse<InspectorUpdateStatusResultDto>> AddAsync(InspectorUpdateStatusRequestDto req);
        Task<BaseResponse<InspectorUpdateStatusResultDto>> GetOne(int factoryId, int periodId);
        Task<BaseResponse<InspectorUpdateStatusResultDto>> UpdateAsync(InspectorUpdateStatusRequestDto req);


    }
}
