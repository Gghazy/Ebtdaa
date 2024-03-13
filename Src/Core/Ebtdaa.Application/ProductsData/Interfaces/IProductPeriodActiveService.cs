using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductPeriodActiveService
    {
        Task<BaseResponse<List<ProductPeriodActiveResultDto>>> AddAsync(List<ProductPeriodActiveRequestDto> req);
    }
}
