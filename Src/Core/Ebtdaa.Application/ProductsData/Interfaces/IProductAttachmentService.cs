using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductAttachmentService
    {
        Task<BaseResponse<List<ProductAttachmentResultDto>>> GetAll();
        Task<BaseResponse<ProductAttachmentResultDto>> AddAsync(ProductAttachmentRequestDto req);
        Task<BaseResponse<ProductAttachmentResultDto>> DeleteAsync(int id);
    }
}
