using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductDataService
    {
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search);
        Task<BaseResponse<QueryResult<ProductResultDto>>> getAllProductsNotInFactory(ProductsNotInFactorySearch search);
        Task<BaseResponse<List<ProductResultDto>>> GetAll(int factoryId);
        Task<BaseResponse<List<ProductResultDto>>> GetAllProducts();
        Task<BaseResponse<ProductResultDto>> GetOne(int Id);
        Task<BaseResponse<bool>> AddAsync(ProductRequestDto request);
        Task<BaseResponse<bool>> UpdateAsync(ProductRequestDto request);
        Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search);



    }
}
