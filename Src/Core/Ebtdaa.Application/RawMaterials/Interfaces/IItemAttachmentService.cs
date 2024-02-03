using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;

namespace Ebtdaa.Application.RawMaterials.Interfaces
{
    public interface IItemAttachmentService
    {
        Task<BaseResponse<List<ItemAttachmentsResultDto>>> GetByItem(int id);
        Task<BaseResponse<ItemAttachmentsResultDto>> GetOne(int id);
        Task<BaseResponse<ItemAttachmentsResultDto>> AddAsync(ItemAttachmentsRequestDto req);
        Task<BaseResponse<ItemAttachmentsResultDto>> UpdateAsync(ItemAttachmentsRequestDto req);

    }
}
