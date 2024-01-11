using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Common.Dtos;

namespace Ebtdaa.Application.ActualRawMaterials.Interfaces
{
    public interface IActualRawFileService
    {
        Task<BaseResponse<List<ActualRawFileResultDto>>> GetAll();
        Task<BaseResponse<ActualRawFileResultDto>> AddAsync(ActualRawFileRequestDto req);
        Task<BaseResponse<ActualRawFileResultDto>> DeleteAsync(int id);
    }
}
