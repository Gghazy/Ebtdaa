using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Dtos;

namespace Ebtdaa.Application.InspectorRawMaterials.Interfaces
{
    public interface IInspectorRawMaterialService
    {
        Task<BaseResponse<List<InspectorRawMaterialResultDto>>> GetAll();
        Task<BaseResponse<InspectorRawMaterialResultDto>> GetByFactory( int id);
        Task<BaseResponse<InspectorRawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<InspectorRawMaterialResultDto>> AddAsync(InspectorRawMaterialRequestDto req);
        Task<BaseResponse<InspectorRawMaterialResultDto>> UpdateAsync(InspectorRawMaterialRequestDto req);

    }
}
