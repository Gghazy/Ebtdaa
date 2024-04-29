using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionProductData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Interfaces
{
    public interface IInspectProductsService
    {
        Task<BaseResponse<List<InspectProductsResultDto>>> GetProducts(int factoryId, int periodId);
        Task<BaseResponse<bool>> AddAsync(InspectProductsRequestDto request);
        Task<BaseResponse<bool>> UpdateAsync(InspectProductsRequestDto request);
    }
}
