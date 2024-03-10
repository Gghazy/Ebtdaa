using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.ProductsData.Validatiton;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;

namespace Ebtdaa.Application.ProductsData.Handlers
{
    public class ProductDataService : IProductDataService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ProductDataValidator _validator;
        private readonly IScreenStatusService _screenStatusService;

        public ProductDataService(IEbtdaaDbContext dbContext, IMapper mapper, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _screenStatusService = screenStatusService;
        }

        public async Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search)
        {



            var resualt = 
                await _dbContext.Products
                .Include(x=>x.Unit)
                .Include(x=>x.ProductPeriodActives)
                .Where(x => x.FactoryId == search.FactoryId)
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto {
                    Hs12NameEn= b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = a.ProductName,
                    CommericalName = a.CommericalName,
                    UnitId = a.UnitId,
                    WiegthInKgm = a.WiegthInKgm,
                    ProductCount = a.ProductCount,
                    ItemNumber = a.ItemNumber,
                    CR = a.CR,
                    Status = a.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Review,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                    IsActive=a.ProductPeriodActives.Any(x=>x.PeriodId==search.PeriodId&&x.ProductId== a.Id),
                })
                .ToQueryResult(search.PageNumber, search.PageSize);

           
            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<List<ProductResultDto>>> GetAll(int factoryId)
        {


            var resualt =
                await _dbContext.Products
                .Include(x => x.Unit)
                .Where(x => x.FactoryId == factoryId)
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = a.ProductName,
                    CommericalName = a.CommericalName,
                    UnitId = a.UnitId,
                    WiegthInKgm = a.WiegthInKgm,
                    ProductCount = a.ProductCount,
                    ItemNumber = a.ItemNumber,
                    CR = a.CR,
                    Status = a.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Review,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                }).ToListAsync();                ;


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<ProductResultDto>> GetOne(int Id)
        {
            var result = await _dbContext
                                .Products
                                .FirstOrDefaultAsync(x => x.Id == Id);

                      var response = _mapper.Map<ProductResultDto>(result);



            return new BaseResponse<ProductResultDto>
            {
                Data = response
            };
        }

        public async Task<BaseResponse<ProductResultDto>> AddAsync (ProductRequestDto request)
        {
            var product = _mapper.Map<Product>(request);
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            await _screenStatusService.CheckFactoryProductScreenStatus(request.FactoryId,request.PeriodId);
            return new BaseResponse<ProductResultDto>
            {
                Data = _mapper.Map<ProductResultDto>(product)
            };

        }

        public async Task<BaseResponse<ProductResultDto>> UpdateAsync(ProductRequestDto req)
        {
            var getProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == req.Id);
            var productUpdated = _mapper.Map(req, getProduct);
            

            await _dbContext.SaveChangesAsync();
            await _screenStatusService.CheckFactoryProductScreenStatus(req.FactoryId, req.PeriodId);


            return new BaseResponse<ProductResultDto>
            {
                Data = _mapper.Map<ProductResultDto>(productUpdated)
            };
        }


        public async Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search)
        {

            var resualt = _mapper.Map<QueryResult<UnitResultDto>>(await _dbContext.Units.ToQueryResult());


            return new BaseResponse<QueryResult<UnitResultDto>>
            {
                Data = resualt
            };

        }

        public async Task<BaseResponse<QueryResult<ProductResultDto>>> getAllProductsNotInFactory(ProductsNotInFactorySearch search)
        {
            var resualt =
                      await _dbContext.Products
                      .Include(x => x.Unit)
                      .Include(x => x.ProductPeriodActives)
                      .Where(x => x.FactoryId != search.FactoryId)
                      .WhereIf(!string.IsNullOrEmpty(search.TxtSearch),x=>x.ProductName.Contains(search.TxtSearch))
                      .ToQueryResult(search.PageNumber, search.PageSize);


            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = _mapper.Map<QueryResult<ProductResultDto>>(resualt)
            };
        }
    }
}
