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
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Application.Units.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Domain.Factories.Entity;

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

        public async Task<BaseResponse<QueryResult<ProductResultDto>>> GetAll(ProductSearch search)
        {
            var resualt = _mapper.Map<QueryResult<ProductResultDto>>(
                await _dbContext.Products
                .Include(x=>x.Unit)
                .Where(x => x.FactoryId == search.FactoryId)
                .ToQueryResult(search.PageNumber, search.PageSize)
                );

            foreach (var item in resualt.Items)
            {
                item.HasCustomLevel = _dbContext.Products.Any(x => x.ParentId == item.Id);
            }
            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }
        public async Task<BaseResponse<List<ProductResultDto>>> ProductLevel12(int factoryId,int productId)
        {
            var resualt = _mapper.Map<List<ProductResultDto>>(
                await _dbContext.Products
                .Where(x=>x.FactoryId==factoryId)
                .Where(x=>x.Level==LevelEnum.Level12)
                .Where(x=>x.ParentId==null || x.ParentId== productId)
                .ToListAsync());

            
            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<QueryResult<ProductResultDto>>> ProductLevel10(ProductSearch search)
        {
            var resualt = _mapper.Map<QueryResult<ProductResultDto>>(
            await _dbContext.Products
                .Where(x => x.FactoryId == search.FactoryId)
                .Where(x=>x.Level==LevelEnum.Level10)
                .ToQueryResult(search.PageNumber, search.PageSize)
                );

            foreach (var item in resualt.Items)
            {
                item.HasCustomLevel = _dbContext.Products.Any(x => x.ParentId == item.Id);
            }
            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
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


        public async Task<BaseResponse<QueryResult<UnitResultDto>>> GetUnit(UnitSearch search)
        {

            var resualt = _mapper.Map<QueryResult<UnitResultDto>>(await _dbContext.Units.ToQueryResult());


            return new BaseResponse<QueryResult<UnitResultDto>>
            {
                Data = resualt
            };

        }

        public async Task<BaseResponse<bool>> SaveCustomLevel(CustomLevelRequestDto request)
        {
            var customLevelProduct = await _dbContext.Products.Where(x => request.CustomLevelProductIds.Contains(x.Id)).ToListAsync();

            foreach (var item in customLevelProduct)
            {
                item.ParentId = request.ProductId;
            }

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data =true
            };
        }
        public async Task<BaseResponse<List<ProductResultDto>>> GetCustomProductLevel(int productId)
        {
            var resualt = _mapper.Map<List<ProductResultDto>>(
                await _dbContext.Products
                .Where(x => x.ParentId == productId)
                .ToListAsync());


            return new BaseResponse<List<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<QueryResult<ProductResultDto>>> GetAllCheckLevel(ProductSearch search)
        {
            var resualt = _mapper.Map<QueryResult<ProductResultDto>>(
                await _dbContext.Products
                .Include(x=>x.Parent)
                .Where(x => x.Level == LevelEnum.Level12)
                .Where(x => x.ParentId !=null)
                .ToQueryResult(search.PageNumber, search.PageSize)
                );

            return new BaseResponse<QueryResult<ProductResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<bool>> SaveCheckLevel(CheckLevelRequestDto request)
        {
            var oldProduct = await _dbContext.Products.FirstOrDefaultAsync(x =>x.Id==request.OldProductId);
            var newProduct = await _dbContext.Products.FirstOrDefaultAsync(x =>x.Id==request.NewProductId);

            oldProduct.ParentId = null;
            newProduct.ParentId = request.ParentId;

             await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
