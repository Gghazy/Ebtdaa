using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionProductData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Interfaces
{
    public interface IInspectProductDataAttachService
    {
        Task<BaseResponse<List<InspectProductAttachResDto>>> GetAll(int id);
        Task<BaseResponse<InspectProductAttachResDto>> AddAsync(InspectProductAttachReqDto req);
    }
}
