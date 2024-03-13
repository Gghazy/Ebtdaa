using AutoMapper;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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



        public async Task<BaseResponse<List<ProductPeriodActiveResultDto>>> AddAsync(List<ProductPeriodActiveRequestDto> list)
        {

            var periodId = list.First().PeriodId;
            var factoryId = list.First().FactoryId;

            var ProductPeriodActives = await _dbContext.ProductPeriodActives.Where(x => x.PeriodId == periodId).ToListAsync();
           
            
            var removList = ProductPeriodActives.Select(x => x.FactoryProductId).Except(list.Select(x=>x.FactoryProductId)).ToList();

            _dbContext.ProductPeriodActives.RemoveRange(ProductPeriodActives);

            var products = _mapper.Map<List<ProductPeriodActive>>(list);
            await _dbContext.ProductPeriodActives.AddRangeAsync(products);
            await _actualProductionService.Delete(factoryId, periodId, removList);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<List<ProductPeriodActiveResultDto>>
            {
                Data = _mapper.Map<List<ProductPeriodActiveResultDto>>(products)
            };
        }

    }
}
