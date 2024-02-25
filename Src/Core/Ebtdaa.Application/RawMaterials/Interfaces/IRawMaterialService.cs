using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.RawMaterials.Interfaces
{
    public interface IRawMaterialService
    {
        Task<BaseResponse<List<RawMaterialResultDto>>> GetAll(int Factoryid, int Periodid);
        Task<BaseResponse<QueryResult<RawMaterialResultDto>>> GetByFactory(RawMaterialSearch search,int id);
        Task<BaseResponse<RawMaterialResultDto>> GetOne(int id);
        Task<BaseResponse<RawMaterialResultDto>> AddAsync(RawMaterialRequestDto req);
        Task<BaseResponse<RawMaterialResultDto>> UpdateAsync(RawMaterialRequestDto req);
      
    }
}
