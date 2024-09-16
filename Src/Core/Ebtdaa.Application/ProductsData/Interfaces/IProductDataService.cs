using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ProductsData.Interfaces
{
    public interface IProductDataService
    {
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search);
        Task<BaseResponse<QueryResult<ProductResultDto>>> getAllProductsNotInFactory(ProductsNotInFactorySearch search);
        Task<BaseResponse<List<ProductResultDto>>> GetAll(int factoryId);
        Task<BaseResponse<List<ProductResultDto>>> GetAddedAll(ProductSearch search);
        Task<BaseResponse<List<ProductResultDto>>> GetAllProducts();
        Task<BaseResponse<List<ProductResultDto>>> AllProductsList(ProductSearch search);
        Task<BaseResponse<List<ProductResultDto>>> AllProductsListToRaw(ProductSearch search);
        Task<BaseResponse<List<ProductResultDto>>> GetProductsList(ProductPaging search);
        Task<BaseResponse<List<ProductResultDto>>> GetAllProductsList(ProductPaging search);
        Task<BaseResponse<List<ProductResultDto>>> GetAllProductsCurrent(ProductPaging search);

        Task<BaseResponse<List<ProductResultDto>>> AllProductsLists(ProductPaging search);



        Task<BaseResponse<ProductResultDto>> GetOne(int Id);
        Task<BaseResponse<ProductResultDto>> GetOneAddedProduct(int Id);
        Task<BaseResponse<ProductResultDto>> GetOneNewProduct(NewProductRequest Id);
        Task<BaseResponse<bool>> AddAsync(ProductRequestDto request);
        Task<BaseResponse<bool>> UpdateAsync(ProductRequestDto request);
        //Task<BaseResponse<ProductResultDto>> DeleteAsync(int id);
        Task<BaseResponse<bool>> DeleteAsync(ProductIdsList id);

        Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search);
        Task<BaseResponse<QueryResult<ProductResultDto>>> GetFactoryProduct(ProductSearch search);



    }
}
