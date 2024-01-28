using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;

namespace Ebtdaa.Application.RawMaterials.Interfaces
{
    public interface IRawMaterialService
    {
        Task<BaseResponse<List<RawMaterialResultDto>>> GetAll();
        Task<BaseResponse<List<RawMaterialResultDto>>> GetByFactory(int id);
        Task<BaseResponse<RawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<RawMaterialResultDto>> AddAsync(RawMaterialRequestDto req);
        Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req);
      
    }
}
