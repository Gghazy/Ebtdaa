using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductDataService
    {
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search);
        Task<BaseResponse<ProductResultDto>> GetOne(int Id);
        Task<BaseResponse<List<ProductResultDto>>> ProductLevel12(int factoryId, int productId);
        Task<BaseResponse<QueryResult<ProductResultDto>>> ProductLevel10(ProductSearch search);
        Task<BaseResponse<ProductResultDto>> AddAsync(ProductRequestDto request);
        Task<BaseResponse<ProductResultDto>> UpdateAsync(ProductRequestDto request);
        Task<BaseResponse<bool>> SaveCustomLevel(CustomLevelRequestDto request);
        Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search);
        Task<BaseResponse<List<ProductResultDto>>> GetCustomProductLevel(int productId);
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetAllCheckLevel(ProductSearch search);
        Task<BaseResponse<bool>> SaveCheckLevel(CheckLevelRequestDto request);



    }
}
