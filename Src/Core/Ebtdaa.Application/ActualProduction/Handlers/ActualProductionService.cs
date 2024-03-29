﻿using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ActualProduction.Handlers
{
    public class ActualProductionService :IActualProductionService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualProductionValidator _actualProductionValidator;
        private readonly IActualProductionAttachService _actualProductionAttachService;
        private readonly IIncreaseActualProductionService _increaseActualProductionService;
        private readonly IScreenStatusService _screenStatusService;


        public ActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper, ActualProductionValidator actualProductionValidator, IActualProductionAttachService actualProductionAttachService, IIncreaseActualProductionService increaseActualProductionService, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualProductionValidator = actualProductionValidator;
            _actualProductionAttachService = actualProductionAttachService;
            _increaseActualProductionService = increaseActualProductionService;
            _screenStatusService = screenStatusService;
        }

        public async Task<BaseResponse<QueryResult<ProductCapacityResultDto>>> GetAll(ActualProductionSearch search)
        {

            var ProductPeriodActives = await _dbContext.ProductPeriodActives
                .Include(x => x.FactoryProduct)
                .ThenInclude(x => x.Product)
                .Where(x => x.PeriodId == search.PeriodId && x.FactoryProduct.FactoryId == search.FactoryId)
                .Select(x => x.FactoryProductId).ToListAsync();

            var resualt = _mapper.Map<QueryResult<ProductCapacityResultDto>>(
                        await _dbContext.FactoryProducts
                        .Include(x => x.Product)
                        .Where(x => ProductPeriodActives.Contains(x.Id))
                        .Where(x => x.FactoryId == search.FactoryId)
                        .Include(x => x.ActualProductionAndCapacities.Where(x => x.PeriodId == search.PeriodId))
                        .ThenInclude(x => x.DesignedCapacityUnit)
                        .Include(x => x.ActualProductionAndCapacities)
                        .ThenInclude(x => x.ActualProductionUint)
                        .ToQueryResult(search.PageNumber, search.PageSize)
                        );

            return new BaseResponse<QueryResult<ProductCapacityResultDto>>
            {
                Data = resualt
            };
        }

        public async Task<BaseResponse<ActualProductionResultDto>> GetOne(int Id)
        {
            var result = await _dbContext.ActualProductionAndCapacities
                                         .FirstOrDefaultAsync(x => x.Id == Id);
            var response = _mapper.Map<ActualProductionResultDto>(result);

            return new BaseResponse<ActualProductionResultDto>
            {
                Data = result != null ? response : new ActualProductionResultDto()
            };
        }

        public async Task<BaseResponse<ActualProductionResultDto>> AddAsync(ActualProductionRequestDto request)
        {
            var actualProduction = _mapper.Map<ActualProductionAndCapacity>(request);

            var result = await _actualProductionValidator.ValidateAsync(actualProduction);
            if (result.IsValid == false) throw new ValidationException(result.Errors);


            await _dbContext.ActualProductionAndCapacities.AddAsync(actualProduction);
            await _dbContext.SaveChangesAsync();
            
            return new BaseResponse<ActualProductionResultDto>
            {
                Data = _mapper.Map<ActualProductionResultDto>(actualProduction)
            };
        }

        public async Task<BaseResponse<ActualProductionResultDto>> UpdateAsync (ActualProductionRequestDto request)
        {
            var getActualproduction = await _dbContext.ActualProductionAndCapacities.FirstOrDefaultAsync(a => a.Id == request.Id);
            var actualproductionUpdated = _mapper.Map(request , getActualproduction);
           

            var result = await _actualProductionValidator.ValidateAsync(actualproductionUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();
           

            return new BaseResponse<ActualProductionResultDto>
            {
                Data = _mapper.Map<ActualProductionResultDto>(actualproductionUpdated)
            };
        }
        public async Task<BaseResponse<bool>> Delete(int factoryId, int periodId,List<int> factoryProducts)
        {
            var result = await _dbContext.ActualProductionAndCapacities
                                      .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId)
                                      .Where(x => factoryProducts.Contains(x.FactoryProductId))
                                      .ToListAsync();


            _dbContext.ActualProductionAndCapacities.RemoveRange(result);

            


            return new BaseResponse<bool>
            {
                Data = true
            };
        }

        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            var result = await _dbContext.ActualProductionAndCapacities
                                      .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId).ToListAsync();


            await _actualProductionAttachService.delete(factoryId, periodId);
            await _increaseActualProductionService.delete(factoryId, periodId);


            _dbContext.ActualProductionAndCapacities.RemoveRange(result);


            return new BaseResponse<bool>
            {
                Data = true
            };
        }

        public async Task<BaseResponse<bool>> UpdateByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            var result = await _dbContext.ActualProductionAndCapacities
                                      .Where(x => x.PeriodId == periodId && x.FactoryProduct.FactoryId == factoryId).ToListAsync();


            await _actualProductionAttachService.delete(factoryId, periodId);
            await _increaseActualProductionService.delete(factoryId, periodId);

            foreach (var item in result)
            {
                item.ActualProduction = null;
                item.ActualProductionUintId = null;
                item.ActualProductionWeight = null;
            }


            return new BaseResponse<bool>
            {
                Data = true
            };
        }


    }
}
