using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductDataService
    {
        Task<BaseResponse<ProductResultDto>> GetOne(int Id);
        Task<BaseResponse<List<ProductResultDto>>> GetAll();
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search);
        Task<BaseResponse<ProductResultDto>> AddAsync(ProductRequestDto request);
        Task<BaseResponse<ProductResultDto>> UpdateAsync(ProductRequestDto request);
        Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetCustomItem_12(CustomsItemSearch search);
        Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search);

    }
}
