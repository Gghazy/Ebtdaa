using AutoMapper;
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
        public ProductPeriodActiveService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public async Task<BaseResponse<List<ProductPeriodActiveResultDto>>> AddAsync(List<ProductPeriodActiveRequestDto> list)
        {

            var periodId = list.First().PeriodId;

            var ProductPeriodActives = await _dbContext.ProductPeriodActives.Where(x => x.PeriodId == periodId).ToListAsync();

            _dbContext.ProductPeriodActives.RemoveRange(ProductPeriodActives);

            var products = _mapper.Map<List<ProductPeriodActive>>(list);
            await _dbContext.ProductPeriodActives.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse<List<ProductPeriodActiveResultDto>>
            {
                Data = _mapper.Map<List<ProductPeriodActiveResultDto>>(products)
            };
        }

    }
}
