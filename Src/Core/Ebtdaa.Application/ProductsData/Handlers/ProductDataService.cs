using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.ProductsData.Validatiton;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.ProductsData.Handlers
{
    public class ProductDataService : IProductDataService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ProductDataValidator _validator;

        public ProductDataService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductResultDto>> GetOne(int Id)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            return new BaseResponse<ProductResultDto>
            {
                Data = _mapper.Map<ProductResultDto>(result)
            };
        }

        public async Task<BaseResponse<ProductResultDto>> AddAsync (ProductRequestDto request)
        {
            var product = _mapper.Map<Product>(request);

            var result = await _validator.ValidateAsync(product);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ProductResultDto>
            {
                Data = _mapper.Map<ProductResultDto>(product)
            };

        }

        public async Task<BaseResponse<ProductResultDto>> UpdateAsync(ProductRequestDto req)
        {
            var getProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == req.Id);
            var productUpdated = _mapper.Map(req, getProduct);

            // Validation
            var result = await _validator.ValidateAsync(productUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ProductResultDto>
            {
                Data = _mapper.Map<ProductResultDto>(productUpdated)
            };
        }

        public async Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetCustomItem_12(CustomsItemSearch search)
        {

            var resualt = _mapper.Map<QueryResult<CUstomsItemLevelResultDto>>(await _dbContext.CustomsItemLevels.Where(l => l.LevelId == CustomsItemLevelEnum.Level12).ToQueryResult());


            return new BaseResponse<QueryResult<CUstomsItemLevelResultDto>>
            {
                Data = resualt
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
    }
}
