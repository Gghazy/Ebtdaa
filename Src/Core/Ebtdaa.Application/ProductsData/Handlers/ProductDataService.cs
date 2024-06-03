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
using Ebtdaa.Domain.Periods;
using System.Collections.Generic;

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

            var productActive = new List<int>();
            if (search.IsActive)
            {
                 productActive =await _dbContext.ProductPeriodActives
                    .Where(x => x.FactoryProduct.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                    .Select(x => x.FactoryProductId).ToListAsync();
            }


            var resualt = 
                await _dbContext.FactoryProducts
                .Include(x=>x.Product)
                .ThenInclude(x=>x.Unit)
              //  .Include(x=>x.ProductPeriodActives)
                .Where(x => x.FactoryId == search.FactoryId )
                .WhereIf(search.IsActive,x=> productActive.Contains(x.Id) )
                .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto {
                    Hs12NameEn= b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ProductName10 = $"{a.Product.ProductName} ({a.Product.ItemNumber})",
                    ProductId=a.ProductId,
                    CommericalName = a.CommericalName,
                    UnitId = a.Product.UnitId,
                    ItemNumber = a.Product.ItemNumber,
                    CR = a.Product.CR,
                    Status = a.Product.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Product.Review,
                    Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                    UnitName = a.Product.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                    IsActive=a.ProductPeriodActives.Any(x=>x.PeriodId==search.PeriodId&&x.FactoryProductId== a.Id),
                })
                .ToQueryResult(search.PageNumber, search.PageSize,sort:"Id",descending:true);

           
            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<List<ProductResultDto>>> GetAll(int factoryId)
        {
            var resualt =
                await _dbContext.FactoryProducts
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Include(x => x.ProductPeriodActives)
                .Where(x => x.FactoryId == factoryId)
                .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductId = a.ProductId,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    CommericalName = a.CommericalName,
                    UnitId = a.Product.UnitId,
                    ItemNumber = a.Product.ItemNumber,
                    CR = a.Product.CR,
                    Status = a.Product.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Product.Review,
                    Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                    UnitName = a.Product.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                }).ToListAsync();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }
        public async Task<BaseResponse<List<ProductResultDto>>> GetAllProducts()
        {
            var resualt =
                await _dbContext.FactoryProducts
                .Include(x => x.Product)
                .ThenInclude(x => x.Unit)
                .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductId = a.ProductId,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    CommericalName = a.CommericalName,
                    UnitId = a.Product.UnitId,
                    ItemNumber = a.Product.ItemNumber,
                    CR = a.Product.CR,
                    Status = a.Product.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Product.Review,
                    Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                    UnitName = a.Product.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                })
                //.ToQueryResult(search.PageNumber, search.PageSize, sort: "Id", descending: true);
                .ToListAsync();

            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<ProductResultDto>> GetOne(int Id)
        {
            var result = await _dbContext
                                .FactoryProducts
                                .Include(x=>x.Product)
                                .ThenInclude(x=>x.Unit)
                               .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                                new ProductResultDto
                               {
                                   Hs12NameEn = b.Hs12NameEn,
                                   Hs12NameAr = b.Hs12NameAr,
                                   Hs12Code = b.Hs12Code,
                                   Id = a.Id,
                                   ProductId = a.ProductId,
                                   ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                                   CommericalName = a.CommericalName,
                                   UnitId = a.Product.UnitId,
                                   ItemNumber = a.Product.ItemNumber,
                                   CR = a.Product.CR,
                                   Status = a.Product.Status,
                                   FactoryId = a.FactoryId,
                                   Review = a.Product.Review,
                                   Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                                   UnitName = a.Product.Unit.Name,
                                   PeperId = a.PeperId,
                                   PhototId = a.PhototId,
                               }).FirstOrDefaultAsync(x => x.Id == Id);

                      var response = _mapper.Map<ProductResultDto>(result);



            return new BaseResponse<ProductResultDto>
            {
                Data = response
            };
        }

        public async Task<BaseResponse<bool>> AddAsync (ProductRequestDto request)
        {
            
            var factoryProduct = new FactoryProduct() ;
            factoryProduct.CommericalName = request.CommericalName;
            factoryProduct.PhototId = request.PhototId;
            factoryProduct.PeperId = request.PeperId;
            factoryProduct.FactoryId = request.FactoryId;
            factoryProduct.ProductId = request.ProductId;

            var product = await _dbContext.Products.FindAsync(request.ProductId);

            product.Kilograms_Per_Unit = request.Kilograms_Per_Unit;

            // Validation
            var result = await _validator.ValidateAsync(factoryProduct);

            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryProducts.AddAsync(factoryProduct);
            await _dbContext.SaveChangesAsync();

            var productPerActive = new ProductPeriodActiveRequestDto()
            {
                FactoryProductId = factoryProduct.Id,
                PeriodId = request.PeriodId
            };
            
            var products = _mapper.Map<ProductPeriodActive>(productPerActive);
            await _dbContext.ProductPeriodActives.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data =true
            };
         
        }

        public async Task<BaseResponse<bool>> UpdateAsync(ProductRequestDto req)
        {
            

            var factoryProduct = await _dbContext.FactoryProducts.Include(x=>x.Product).FirstAsync(x => x.Id == req.Id);
            factoryProduct.CommericalName = req.CommericalName;
            factoryProduct.PhototId = req.PhototId;
            factoryProduct.PeperId = req.PeperId;
            factoryProduct.Product.Kilograms_Per_Unit = req.Kilograms_Per_Unit;

            await _dbContext.SaveChangesAsync();



            return new BaseResponse<bool>
            {
                Data = true
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
                      await _dbContext.FactoryProducts
                      .Include(x=>x.Product)        
                      .ThenInclude(x => x.Unit)
                      .Include(x => x.ProductPeriodActives)
                      .Where(x => x.FactoryId != search.FactoryId)
                      .WhereIf(!string.IsNullOrEmpty(search.TxtSearch),x=>x.Product.ProductName.Contains(search.TxtSearch))
                       .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductId = a.ProductId,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    CommericalName = a.CommericalName,
                    UnitId = a.Product.UnitId,
                    ItemNumber = a.Product.ItemNumber,
                    CR = a.Product.CR,
                    Status = a.Product.Status,
                    FactoryId = a.FactoryId,
                    Review = a.Product.Review,
                    Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                    UnitName = a.Product.Unit.Name,
                    PeperId = a.PeperId,
                    PhototId = a.PhototId,
                })
                      .ToQueryResult(search.PageNumber, search.PageSize);


            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = _mapper.Map<QueryResult<ProductResultDto>>(resualt)
            };
        }

        public async Task<BaseResponse<List<ProductResultDto>>> GetAddedAll(int factoryId)
        {
            var resualt =
               await _dbContext.FactoryProducts
               .Include(x => x.Product)
               .ThenInclude(x => x.Unit)
               .Where(x => x.FactoryId == factoryId)
               .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
               new ProductResultDto
               {
                   Hs12NameEn = b.Hs12NameEn,
                   Hs12NameAr = b.Hs12NameAr,
                   Hs12Code = b.Hs12Code,
                   Id = a.Id,
                   ProductId = a.ProductId,
                   ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                   CommericalName = a.CommericalName,
                   UnitId = a.Product.UnitId,
                   ItemNumber = a.Product.ItemNumber,
                   CR = a.Product.CR,
                   Status = a.Product.Status,
                   FactoryId = a.FactoryId,
                   Review = a.Product.Review,
                   Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
                   UnitName = a.Product.Unit.Name,
                   PeperId = a.PeperId,
                   PhototId = a.PhototId,
               }).ToListAsync();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }
       
    }
}
