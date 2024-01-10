using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductDataService
    {
        Task<BaseResponse<ProductResultDto>> GetOne(int Id);
        Task<BaseResponse<ProductResultDto>> AddAsync(ProductRequestDto request);
        Task<BaseResponse<ProductResultDto>> UpdateAsync(ProductRequestDto request);
        Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetCustomItem_12(CustomsItemSearch search);
        Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search);

    }
}
