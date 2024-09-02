using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Handlers
{
    public class ProductPeriodActiveService : IProductPeriodActiveService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public readonly IActualProductionService _actualProductionService;
        public ProductPeriodActiveService(IEbtdaaDbContext dbContext, IMapper mapper, IActualProductionService actualProductionService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualProductionService = actualProductionService;
        }
        public async Task addAcutalProductCapacity(List<int> factoryProducts,int periodId, int factoryId)
        {

            var actualProduction = 
                        await _dbContext.FactoryProducts
                        .Include(x => x.Product)
                        .ThenInclude(x => x.Unit)
                        .Where(x => factoryProducts.Contains(x.Id))
                        .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId)
                        .Include(x => x.ActualProductionAndCapacities.Where(x => x.PeriodId == periodId))
                        .ThenInclude(x => x.DesignedCapacityUnit)
                        .Include(x => x.ActualProductionAndCapacities)
                        .ThenInclude(x => x.ActualProductionUint)
                        .Join(_dbContext.MappingProducts, a => a.Product.ItemNumber, b => b.Hs10Code, (a, b) =>
                        new ActualProductionAndCapacity
                        {
                            AcuProductName = $"{b.Hs12NameAr} ({b.Hs12Code})",
                            AcuKilograms_Per_Unit = a.Product.Kilograms_Per_Unit!=null?(double)a.Product.Kilograms_Per_Unit:0,
                            FactoryProductId = a.Id,
                            PeriodId = a.PeriodId,
                            ActualProductionUintId = a.Product.UnitId,
                            DesignedCapacityUnitId = a.Product.UnitId,
                            DesignedCapacity = a.ActualProductionAndCapacities.Count > 0 ? a.ActualProductionAndCapacities.FirstOrDefault().DesignedCapacity : 0,
                            ActualProduction = a.ActualProductionAndCapacities.Count > 0 ? a.ActualProductionAndCapacities.FirstOrDefault().ActualProduction : 0,
                            ActualProductionWeight =(int?)(a.ActualProductionAndCapacities.Count > 0 ? a.ActualProductionAndCapacities.FirstOrDefault().ActualProduction * (a.Product.Kilograms_Per_Unit != null ? (double)a.Product.Kilograms_Per_Unit : 0) : 0),

                        }).ToListAsync();

            await _dbContext.ActualProductionAndCapacities.AddRangeAsync(actualProduction);
            await _dbContext.SaveChangesAsync();
        }


    public async Task<BaseResponse<List<ProductPeriodActiveResultDto>>> AddAsync(List<ProductPeriodActiveRequestDto> list)
        {
            try
            {

                var periodId = list.First().PeriodId;
                var factoryId = list.First().FactoryId;


                var ProductPeriodActives = await _dbContext.ProductPeriodActives.Where(x => x.PeriodId == periodId && x.FactoryId == factoryId).ToListAsync();


                var removList = ProductPeriodActives.Select(x => x.ProductId).Except(list.Select(x => x.ProductId)).ToList();


                var allList = ProductPeriodActives.Select(x => x.ProductId);

                /*var removList = ProductPeriodActives.Where(r =>
                   allList.Contains(r.ProductId)
                   ).Select(r=>r.ProductId).ToList();*/

                var newList = list.Where(r =>
                   !allList.Contains(r.ProductId)
                   ).ToList();

                var ProductPeriodActivesR = ProductPeriodActives.Where(r =>
                   removList.Contains(r.ProductId)
                   ).ToList();

                _dbContext.ProductPeriodActives.RemoveRange(ProductPeriodActivesR);

                var products = _mapper.Map<List<ProductPeriodActive>>(newList);

                await _dbContext.ProductPeriodActives.AddRangeAsync(products);

                if (removList.Count != 0)
                {
                    var resultFP = await _dbContext.FactoryProducts
                                               .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                                               .Where(x => removList.Contains(x.ProductId))
                                               .ToListAsync();

                    _dbContext.FactoryProducts.RemoveRange(resultFP);
                    var removeIds = resultFP.Select(r => r.Id).ToList();

                    var result = await _dbContext.ActualProductionAndCapacities
                        .Include("FactoryProduct")
                                              .Where(x => x.PeriodId == periodId)
                                              .Where(x => removList.Contains(x.FactoryProduct.ProductId))
                                              .ToListAsync();


                    _dbContext.ActualProductionAndCapacities.RemoveRange(result);

                }

                List<FactoryProduct> factoryProducts = products.Select(x =>
                new FactoryProduct
                {
                    CommericalName = "",
                    PhototId = null,
                    PeperId = null,
                    FactoryId = factoryId,
                    ProductId = x.ProductId,
                    PeriodId = periodId,
                }).ToList();



                await _dbContext.FactoryProducts.AddRangeAsync(factoryProducts);

                await _dbContext.SaveChangesAsync();

                var ids = factoryProducts.Select(r => r.Id).ToList();
                await addAcutalProductCapacity(ids, periodId, factoryId);

                return new BaseResponse<List<ProductPeriodActiveResultDto>>
                {
                    Data = _mapper.Map<List<ProductPeriodActiveResultDto>>(products),
                    IsSuccess= true,
                };
            }
            catch (Exception ex) {
                return new BaseResponse<List<ProductPeriodActiveResultDto>>
                {
                    Data = new List<ProductPeriodActiveResultDto>(),
                    IsSuccess = false,
                };
            }
           
        }
        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            var result = await _dbContext.ProductPeriodActives
                                     .Include(x => x.Product)
                                     .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                                     .ToListAsync();
            _dbContext.ProductPeriodActives.RemoveRange(result);

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
