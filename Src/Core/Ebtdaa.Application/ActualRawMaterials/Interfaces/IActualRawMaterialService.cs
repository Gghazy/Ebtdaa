using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;

namespace Ebtdaa.Application.ActualRawMaterials.Interfaces
{
    public interface IActualRawMaterialService
    {
        Task<BaseResponse<List<ActualRawMaterialResultDto>>> GetAll();
        Task<BaseResponse<List<ActualRawMaterialResultDto>>> GetByPeriod(int factoryid,int period);
        Task<BaseResponse<ActualRawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<ActualRawMaterialResultDto>> AddAsync(ActualRawMaterialRequestDto req);
        Task<BaseResponse<ActualRawMaterialResultDto>> UpdateAsync(ActualRawMaterialRequestDto req);
     
    }
}
