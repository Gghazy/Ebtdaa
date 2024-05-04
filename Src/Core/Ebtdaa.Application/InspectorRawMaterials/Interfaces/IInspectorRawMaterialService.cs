using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;

namespace Ebtdaa.Application.InspectorRawMaterials.Interfaces
{
    public interface IInspectorRawMaterialService
    {
       Task<BaseResponse<List<InspectorRawMaterialResultDto>>> GetAll(int factoryId, int periodId, string ownerIdentity);
        Task<BaseResponse<InspectorRawMaterialResultDto>> AddAsync(InspectorRawMaterialRequestDto req);
        Task<BaseResponse<InspectorRawMaterialResultDto>> UpdateAsync(InspectorRawMaterialRequestDto req);

    }
}
