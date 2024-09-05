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
using Ebtdaa.Domain.ActualProduction.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Ebtdaa.Application.RawMaterials.Dtos;
using System.Collections;

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
           // if (search.IsActive)
            //{
                 productActive =await _dbContext.ProductPeriodActives
                    .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                    .Select(x => x.ProductId).ToListAsync();
            //}
            var productInfactory = await _dbContext.ProductPeriodActives
                      .Where(x => x.FactoryId == search.FactoryId && x.PeriodId != search.PeriodId)
                      .Select(x => x.ProductId).ToListAsync();
            var getCR = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == search.FactoryId);

            var resualt =
                    await _dbContext.Products
                    .Include(x => x.Unit)
                    .Include(x=>x.ProductPeriodActives)
                    //.Include(x=>x.FactoryProducts)
                   .Where(r => r.CR == getCR.CommercialRegister || productActive.Contains(r.Id) || productInfactory.Contains(r.Id))
                    //.Where(x=>x.ProductPeriodActives.Any(r=>r.FactoryId==search.FactoryId&&r.PeriodId==r.PeriodId))
                    .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                    new ProductResultDto
                    {
                        Hs12NameEn = b.Hs12NameEn,
                        Hs12NameAr = b.Hs12NameAr,
                        Hs12Code = b.Hs12Code,
                        Id = a.Id,
                        ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                        ProductName10 = $"{a.ProductName} ({a.ItemNumber})",
                        ProductId = a.Id,
                        UnitId = a.UnitId,
                        ItemNumber = a.ItemNumber,
                        CR = a.CR,
                        Status = a.Status,
                        FactoryId = search.FactoryId,
                        Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                        UnitName = a.Unit.Name, 
                        IsActive = productActive.Contains(a.Id),
                    })
                    .ToQueryResult(search.PageNumber, search.PageSize, sort: "Id", descending: true);


            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };

        }
        public async Task<BaseResponse<QueryResult<ProductResultDto>>> GetFactoryProduct(ProductSearch search)
        {

            var productActive = new List<int>();
            if (search.IsActive)
            {
                productActive = await _dbContext.ProductPeriodActives
                   .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                   .Select(x => x.ProductId).ToListAsync();


            }

         
            var addedProduct =
            await _dbContext.FactoryProducts
            .Include(x => x.Product)
            .ThenInclude(x => x.Unit)
            .Include(x => x.ProductPeriodActives)
            .Where(x => x.FactoryId == search.FactoryId)
            .WhereIf(search.IsActive, x => productActive.Contains(x.ProductId))
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

            var added = addedProduct.Select(x => x.ProductId);

            var factoryProduct = await _dbContext.FactoryProducts.FirstOrDefaultAsync(t => t.FactoryId == search.FactoryId && t.PeriodId == search.PeriodId);

            var resualt = await _dbContext.Products
            .Include(x => x.Unit)
                  .WhereIf(search.IsActive, x => productActive.Contains(x.Id))
                  .Where((x => !(added.Contains(x.Id))))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = 0,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ProductName10 = $"{a.ProductName} ({a.ItemNumber})",
                    ProductId = a.Id,
                    CommericalName = " لا يوجد ",
                    UnitId = a.UnitId,
                    ItemNumber = a.ItemNumber,
                    CR = a.CR,
                    Status = a.Status,
                    FactoryId = search.FactoryId,
                    Review = a.Review,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                    PeperId = null,
                    PhototId = null, 
                    IsActive = a.ProductPeriodActives.Any(x => x.PeriodId == search.PeriodId && x.ProductId == a.Id),
                })

                .ToQueryResult(search.PageNumber, search.PageSize, sort: "Id", descending: true);


            resualt.AddItems(resualt.Items.Concat(addedProduct).ToList());
          

            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }
        public async Task<BaseResponse<ProductResultDto>> GetOneAddedProduct(int Id)
        {
            var result = await _dbContext.FactoryProducts
                                .Include(x => x.Product)
                                .ThenInclude(x => x.Unit)
                                .Include(x => x.ActualProductionAndCapacities)
                               //.ThenInclude(x=>x.ActualProductionUintId)
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
                                    Level12Number = b.Hs12Code,

                                }).FirstOrDefaultAsync(x => x.Id == Id);

            var response = _mapper.Map<ProductResultDto>(result);



            return new BaseResponse<ProductResultDto>
            {
                Data = response
            };
        }
        public async Task<BaseResponse<ProductResultDto>> GetOneNewProduct(NewProductRequest items)
        {

            var productActive = new List<int>();

            productActive = await _dbContext.ProductPeriodActives
               .Where(x => x.FactoryId == items.FactoryId && x.PeriodId == items.PeriodId && x.ProductId == items.ProductId)
               .Select(x => x.ProductId).ToListAsync();


            //var getCR = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == items.FactoryId);


            var result =
                await _dbContext.Products
                // .Include(x => x.Unit)
                .Where(x => productActive.Contains(items.ProductId))
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                 new ProductResultDto
                 {
                     Hs12NameEn = b.Hs12NameEn,
                     Hs12NameAr = b.Hs12NameAr,
                     Hs12Code = b.Hs12Code,
                     Id = 0,
                     ProductId = a.Id,
                     ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                     CommericalName = "",
                     UnitId = a.UnitId,
                     ItemNumber = a.ItemNumber,
                     CR = a.CR,
                     Status = a.Status,
                     FactoryId = items.FactoryId,
                     Review = a.Review,
                     Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                     UnitName = a.Unit.Name,
                     PeperId = null,
                     PhototId = null,
                     Level12Number = b.Hs12Code,
                 }).
                  FirstOrDefaultAsync(x => x.ProductId == items.ProductId);

            var response = _mapper.Map<ProductResultDto>(result);



            return new BaseResponse<ProductResultDto>
            {
                Data = response
            };
        }


        /*
        public async Task<BaseResponse<QueryResult<ProductResultDto>>> GetFactoryProduct(ProductSearch search)
        {

            var productActive = new List<int>();
            if (search.IsActive)
            {
                productActive = await _dbContext.ProductPeriodActives
                   .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                   .Select(x => x.ProductId).ToListAsync();


            }

           

        var factoryProduct = await _dbContext.FactoryProducts.FirstOrDefaultAsync(t => t.FactoryId == search.FactoryId && t.PeriodId == search.PeriodId);
          
            var resualt = await _dbContext.Products
            .Include(x => x.Unit)
            .Include(x => x.FactoryProducts)
                  .WhereIf(search.IsActive, x => productActive.Contains(x.Id))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ProductName10 = $"{a.ProductName} ({a.ItemNumber})",
                    ProductId = a.Id,
                    CommericalName = factoryProduct != null && factoryProduct.ProductId== a.Id ? factoryProduct.CommericalName : "",
                    UnitId = a.UnitId,
                    ItemNumber = a.ItemNumber,
                    CR = a.CR,
                    Status = a.Status,
                    FactoryId = search.FactoryId,
                    Review = a.Review,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                    PeperId = factoryProduct != null && factoryProduct.ProductId == a.Id ? factoryProduct.PeperId : 0,
                    PhototId = factoryProduct != null && factoryProduct.ProductId == a.Id ? factoryProduct.PhototId : 0,
                    IsActive = a.ProductPeriodActives.Any(x => x.PeriodId == search.PeriodId && x.ProductId == a.Id),
                })
                .ToQueryResult(search.PageNumber, search.PageSize, sort: "Id", descending: true);

            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }
       */
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
        /*public async Task<BaseResponse<List<ProductResultDto>>> GetProductsList(ProductPaging search)
        {


            var ExsitsProductInRaw = await _dbContext.RawMaterials
                .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                .Select(x => Int64.Parse(x.CustomItemName)).ToListAsync();

            var res =
                   _dbContext.Products
                  .Include(x => x.Unit)
                  .Where(x => !ExsitsProductInRaw.Contains(x.Id))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                  new ProductResultDto
                  {
                      Hs12NameEn = b.Hs12NameEn,
                      Hs12NameAr = b.Hs12NameAr,
                      Hs12Code = b.Hs12Code,
                      Id = a.Id,
                      ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                      ItemNumber = a.ItemNumber,
                      ProductId = a.Id,
                      UnitId = a.UnitId,
                      CR = a.CR,
                      Status = a.Status,
                      Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                      UnitName = a.Unit.Name,
                  }).AsQueryable();
          
             var  result = res.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToList();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = result
            };
        }*/


        public async Task<BaseResponse<List<ProductResultDto>>> GetProductsList(ProductPaging search)
        {


            var ExsitsProductInRaw = await _dbContext.RawMaterials
                .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                .Select(x => Int64.Parse(x.CustomItemName)).ToListAsync();

            var res =
                   _dbContext.Products
                  .Include(x => x.Unit)
                  .Where(x => !ExsitsProductInRaw.Contains(x.Id))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                  new ProductResultDto
                  {
                      Hs12NameEn = b.Hs12NameEn,
                      Hs12NameAr = b.Hs12NameAr,
                      Hs12Code = b.Hs12Code,
                      Id = a.Id,
                      ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                      ItemNumber = a.ItemNumber,
                      ProductId = a.Id,
                      UnitId = a.UnitId,
                      CR = a.CR,
                      Status = a.Status,
                      Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                      UnitName = a.Unit.Name,
                  }).AsQueryable();
            List<ProductResultDto> result = new List<ProductResultDto>();
            if (!string.IsNullOrEmpty(search.SearchText))
            {
                var query = await res.ToListAsync();
                query = query.Where(p => p.ProductName.Contains(search.SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                result =query.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToList();
            }
            else
           result = await res.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToListAsync();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = result
            };
        }

        public async Task<BaseResponse<List<ProductResultDto>>> GetAllProductsList(ProductPaging search)
        {


           
            var res =  _dbContext.Products
                .Include(x => x.Unit)
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ItemNumber = a.ItemNumber,
                    ProductId = a.Id,
                    UnitId = a.UnitId,
                    CR = a.CR,
                    Status = a.Status,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                })
            .AsQueryable();
            List<ProductResultDto> result = new List<ProductResultDto>();
            if (!string.IsNullOrEmpty(search.SearchText))
            {
                var query = await res.ToListAsync();
                query = query.Where(p => p.ProductName.Contains(search.SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                result = query.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToList();
            }
            else
                result =await res.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToListAsync();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = result
            };
        }
        public async Task<BaseResponse<bool>> DeleteAsync(ProductIdsList idsList)
        {
            try
            {
                var ids = idsList.ids;
                var FactoryProductsItems = await _dbContext.FactoryProducts.Include("Product").Where(i => ids.Contains(i.Id)).ToListAsync();

                if (FactoryProductsItems == null || !FactoryProductsItems.Any())
                {
                    //
                }

                _dbContext.FactoryProducts.RemoveRange(FactoryProductsItems);

                var factoryids = FactoryProductsItems.Select(r=>r.ProductId).ToList();
                var ActualProductionAndCapacitiesItems = await _dbContext.ActualProductionAndCapacities.Where(i => ids.Contains(i.FactoryProductId)).ToListAsync();

                if (ActualProductionAndCapacitiesItems == null || !ActualProductionAndCapacitiesItems.Any())
                {
                    //
                }

                _dbContext.ActualProductionAndCapacities.RemoveRange(ActualProductionAndCapacitiesItems);

                var ProductPeriodActivesItems = await _dbContext.ProductPeriodActives
                    .Where(x =>x.PeriodId == FactoryProductsItems.FirstOrDefault().PeriodId
                    && x.FactoryId == FactoryProductsItems.FirstOrDefault().FactoryId 
                    && factoryids.Contains(x.ProductId) ).ToListAsync();

                if (ProductPeriodActivesItems == null || !ProductPeriodActivesItems.Any())
                {
                    //
                }

                _dbContext.ProductPeriodActives.RemoveRange(ProductPeriodActivesItems);
                /*
                foreach (var id in ids)
                {
                    var factoryPrduct = await _dbContext.FactoryProducts.FirstOrDefaultAsync(x => x.Id == id);
                    var actualProduct = await _dbContext.ActualProductionAndCapacities.FirstOrDefaultAsync(x => x.FactoryProductId == id);
                    var ProductPeriodActive = await _dbContext.ProductPeriodActives.FirstOrDefaultAsync
                        (x => x.PeriodId == factoryPrduct.PeriodId && x.FactoryId == factoryPrduct.FactoryId && x.ProductId == factoryPrduct.ProductId);

                    _dbContext.ActualProductionAndCapacities.Remove(actualProduct);
                    _dbContext.FactoryProducts.Remove(factoryPrduct);
                    _dbContext.ProductPeriodActives.Remove(ProductPeriodActive);
                }
                */
                //  _dbContext.RawMaterials.State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess = true
                };
            }
            catch   (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    IsSuccess = false
                };
            }
        }
        public async Task<BaseResponse<List<ProductResultDto>>> AllProductsListToRaw(ProductSearch search)
        {


            var ExsitsProductInRaw = await _dbContext.RawMaterials
                .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                .Select(x =>Int64.Parse( x.CustomItemName)).ToListAsync();

            var resualt =
                  await _dbContext.Products
                  .Include(x => x.Unit)
                  .Where(x => !ExsitsProductInRaw.Contains(x.Id))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                  new ProductResultDto
                  {
                      Hs12NameEn = b.Hs12NameEn,
                      Hs12NameAr = b.Hs12NameAr,
                      Hs12Code = b.Hs12Code,
                      Id = a.Id,
                      ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                      ItemNumber = a.ItemNumber,
                      ProductId = a.Id,
                      UnitId = a.UnitId,
                      CR = a.CR,
                      Status = a.Status,
                      Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                      UnitName = a.Unit.Name,
                  })
                  .ToListAsync();


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }
        public async Task<BaseResponse<List<ProductResultDto>>> AllProductsLists(ProductPaging search)
        {

            var getCR = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == search.FactoryId);


            var ExsitsProduct = await _dbContext.FactoryProducts
                .Where(x => x.FactoryId == search.FactoryId)//&& x.PeriodId == search.PeriodId
                .Select(x => x.ProductId).ToListAsync();


            var res =
                   _dbContext.Products
                  .Include(x => x.Unit)
                  .Where(x => !(x.CR == getCR.CommercialRegister) && !(ExsitsProduct.Contains(x.Id)))
                  .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                  new ProductResultDto
                  {
                      Hs12NameEn = b.Hs12NameEn,
                      Hs12NameAr = b.Hs12NameAr,
                      Hs12Code = b.Hs12Code,
                      Id = a.Id,
                      ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                      ItemNumber = a.ItemNumber,
                      ProductId = a.Id,
                      UnitId = a.UnitId,
                      CR = a.CR,
                      Status = a.Status,
                      Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                      UnitName = a.Unit.Name,
                  })
               .AsQueryable();
           
            List<ProductResultDto> result = new List<ProductResultDto>();
            if (!string.IsNullOrEmpty(search.SearchText))
            {
                var query = await res.ToListAsync();
                query = query.Where(p => p.ProductName.Contains(search.SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                result = query.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToList();
            }
            else
                result =await res.Skip(search.CurrentPage * search.PageSize).Take(search.PageSize).ToListAsync();





            return new BaseResponse<List<ProductResultDto>>
            {
                Data = result
            };
        }

        public async Task<BaseResponse<List<ProductResultDto>>> AllProductsList(ProductSearch search)
        {

            var getCR = await _dbContext.Factories.FirstOrDefaultAsync(f => f.Id == search.FactoryId);


            var ExsitsProduct = await _dbContext.FactoryProducts
                .Where(x => x.FactoryId == search.FactoryId && x.PeriodId == search.PeriodId)
                .Select(x => x.ProductId).ToListAsync();

            
          var resualt =
                await _dbContext.Products
                .Include(x => x.Unit)
                .Where(x => !(x.CR == getCR.CommercialRegister) && !(ExsitsProduct.Contains(x.Id)))
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ItemNumber = a.ItemNumber,
                    ProductId = a.Id,
                    UnitId = a.UnitId,
                    CR = a.CR,
                    Status = a.Status,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                })
                .ToListAsync();

           


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }
        public async Task<BaseResponse<List<ProductResultDto>>> GetAllProducts()
        {
            var resualt =
                await _dbContext.Products
                .Include(x => x.Unit)
                .Join(_dbContext.MappingProducts, a => a.ItemNumber, b => b.Hs10Code, (a, b) =>
                new ProductResultDto
                {
                    Hs12NameEn = b.Hs12NameEn,
                    Hs12NameAr = b.Hs12NameAr,
                    Hs12Code = b.Hs12Code,
                    Id = a.Id,
                    ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                    ItemNumber = a.ItemNumber,
                    ProductId = a.Id,
                    UnitId = a.UnitId,
                    CR = a.CR,
                    Status = a.Status,
                    Kilograms_Per_Unit = a.Kilograms_Per_Unit,
                    UnitName = a.Unit.Name,
                })
                .ToListAsync();
            //var resualt =
            //    await _dbContext.FactoryProducts
            //    .Include(x => x.Product)
            //    .ThenInclude(x => x.Unit)
            //    .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
            //    new ProductResultDto
            //    {
            //        Hs12NameEn = b.Hs12NameEn,
            //        Hs12NameAr = b.Hs12NameAr,
            //        Hs12Code = b.Hs12Code,
            //        Id = a.Id,
            //        ProductId = a.ProductId,
            //        ProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
            //        CommericalName = a.CommericalName,
            //        UnitId = a.Product.UnitId,
            //        ItemNumber = a.Product.ItemNumber,
            //        CR = a.Product.CR,
            //        Status = a.Product.Status,
            //        FactoryId = a.FactoryId,
            //        Review = a.Product.Review,
            //        Kilograms_Per_Unit = a.Product.Kilograms_Per_Unit,
            //        UnitName = a.Product.Unit.Name,
            //        PeperId = a.PeperId,
            //        PhototId = a.PhototId,
            //    })
            //    //.ToQueryResult(search.PageNumber, search.PageSize, sort: "Id", descending: true);
            //    .ToListAsync();

            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<ProductResultDto>> GetOne(int Id)
        {
            var result = await _dbContext.FactoryProducts
                                .Include(x=>x.Product)
                                .ThenInclude(x=>x.Unit)
                                .Include(x=>x.ActualProductionAndCapacities)
                                //.ThenInclude(x=>x.ActualProductionUintId)
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
                                   Level12Number = b.Hs12Code,
                                   
                               }).FirstOrDefaultAsync(x => x.Id == Id);

                      var response = _mapper.Map<ProductResultDto>(result);



            return new BaseResponse<ProductResultDto>
            {
                Data = response
            };
        }

        public async Task<BaseResponse<bool>> AddAsync (ProductRequestDto request)
        {
            try
            {
                var factoryProduct = new FactoryProduct();
                factoryProduct.CommericalName = request.CommericalName;
                factoryProduct.PhototId = request.PhototId;
                factoryProduct.PeperId = request.PeperId;
                factoryProduct.FactoryId = request.FactoryId;
                factoryProduct.ProductId = request.ProductId;
                factoryProduct.PeriodId = request.PeriodId;

                var product = await _dbContext.Products.FindAsync(request.ProductId);

                product.Kilograms_Per_Unit = request.Kilograms_Per_Unit;
                
               await _dbContext.FactoryProducts.AddAsync(factoryProduct);

                var productPerActive = new ProductPeriodActiveRequestDto()
                {
                    ProductId = request.ProductId,
                    PeriodId = request.PeriodId,
                    FactoryId = request.FactoryId,
                    
                    
                };

                var products = _mapper.Map<ProductPeriodActive>(productPerActive);
                await _dbContext.ProductPeriodActives.AddAsync(products);
                //await _dbContext.SaveChangesAsync();
                await _dbContext.SaveChangesAsync();

                var getItemNumber12 = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
                
              
                /* var newProduct = new Product();
                 newProduct.CR = product.CR;
                 newProduct.ItemNumber = getItemNumber12.ItemNumber;
                 newProduct.Kilograms_Per_Unit = request.Kilograms_Per_Unit;
                 newProduct.UnitId = request.UnitId;
                 newProduct.ProductName = request.CommericalName;


                 await _dbContext.Products.AddAsync(newProduct);*/
               // await _dbContext.SaveChangesAsync();
               await addAcutalProductCapacity(factoryProduct.Id,(double)request.Kilograms_Per_Unit);

                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess=  true,
                };
            }
            catch (Exception ex) 
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                };
            }
           
         
        }
        public async Task addAcutalProductCapacity(int productId, double kilograms_Per_Unit)
        {

            var actualProduction =
                        await _dbContext.FactoryProducts
                        .Include(x => x.Product)
                        .ThenInclude(x => x.Unit)
                        .Where(x => x.Id== productId)
                        .Include(x => x.ActualProductionAndCapacities)
                        .ThenInclude(x => x.ActualProductionUint)
                        .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                        new ActualProductionAndCapacity
                        {
                            AcuProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                            AcuKilograms_Per_Unit = kilograms_Per_Unit,
                            FactoryProductId = a.Id,
                            PeriodId = a.PeriodId,
                            ActualProductionUintId = a.Product.UnitId,
                            DesignedCapacityUnitId = a.Product.UnitId,
                            DesignedCapacity = a.ActualProductionAndCapacities.Count > 0 ? a.ActualProductionAndCapacities.FirstOrDefault().DesignedCapacity : 0,
                            ActualProduction = a.ActualProductionAndCapacities.Count > 0 ? a.ActualProductionAndCapacities.FirstOrDefault().ActualProduction : 0,

                        }).FirstOrDefaultAsync();

            await _dbContext.ActualProductionAndCapacities.AddAsync(actualProduction);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<BaseResponse<bool>> UpdateAsync(ProductRequestDto req)
        {
            try
            {
                var factoryProduct = await _dbContext.FactoryProducts.Include("Product").FirstOrDefaultAsync(x => x.Id == req.Id);

                if (factoryProduct != null)
                {
                    factoryProduct.CommericalName = req.CommericalName;
                    if (req.PhototId != null)
                    {
                        if (req.PhototId > 0)
                            factoryProduct.PhototId = req.PhototId;
                    }
                    if (req.PeperId != null)
                    {
                        if (req.PeperId > 0)
                            factoryProduct.PeperId = req.PeperId;
                    }
                    var ActualProduct = await _dbContext.ActualProductionAndCapacities.FirstOrDefaultAsync(x => x.FactoryProductId == req.Id);
                    ActualProduct.AcuKilograms_Per_Unit = (double)req.Kilograms_Per_Unit;
                    factoryProduct.Product.Kilograms_Per_Unit = req.Kilograms_Per_Unit;

                    ActualProduct.ActualProductionWeight =
                     (int?)(ActualProduct.ActualProduction * ActualProduct.AcuKilograms_Per_Unit);


                    await _dbContext.SaveChangesAsync();

                }
                //await _dbContext.FactoryProducts.AddRangeAsync(factoryProduct);
                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                };
            }



        }

/*
        public async Task<BaseResponse<bool>> UpdateAsync(ProductRequestDto req)
        {
            try
            {
                var factoryProduct = await _dbContext.FactoryProducts.Include(x => x.Product).FirstAsync(x => x.ProductId == req.ProductId && x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId);

                factoryProduct.CommericalName = req.CommericalName;
                if(req.PhototId !=0)
                {
                    factoryProduct.PhototId = req.PhototId;
                }
                if(req.PeperId !=0)
                {
                    factoryProduct.PeperId = req.PeperId;
                }
                factoryProduct.Product.Kilograms_Per_Unit = req.Kilograms_Per_Unit;

                //await _dbContext.FactoryProducts.AddRangeAsync(factoryProduct);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception  ex) 
            {
                throw;
            }
            

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
      */
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

        public async Task<BaseResponse<List<ProductResultDto>>> GetAddedAll(ProductSearch search)
        {
            var resualt =
               await _dbContext.FactoryProducts
               .Include(x => x.Product)
               .ThenInclude(x => x.Unit)
               .Where(x => x.FactoryId == search.FactoryId &&x.PeriodId==search.PeriodId)
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
