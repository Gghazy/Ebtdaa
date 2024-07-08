using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.RawMaterials.Interfaces
{
    public interface IRawMaterialService
    {
        Task<BaseResponse<List<RawMaterialResultDto>>> GetAll();

        Task<BaseResponse<List<RawMaterialResultDto>>> getAllRawMaterial(RawMaterialSearch search, int id);

        
        Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id);
        Task<BaseResponse<RawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<RawMaterialResultDto>> AddAsync(RawMaterialRequestDto req);
        Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req);
        Task<BaseResponse<RawMaterialResultDto>> DeleteAsync(int id);
        Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId);

    }
}
