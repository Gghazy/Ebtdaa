using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Handlers
{
    public class ActualProductionService :IActualProductionService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualProductionValidator _actualProductionValidator;

        public async Task<BaseResponse<QueryResult<ProductCapacityResultDto>>> GetAll(ActualProductionSearch search)
        {
            var resualt = _mapper.Map<QueryResult<ProductCapacityResultDto>>(
                        await _dbContext.Products
                        .Where(x=>x.FactoryId==search.FactoryId)
                        .Where(x=>x.Level==LevelEnum.Level12)
                        .Include(x => x.ActualProductionAndCapacities.Where(x=>x.PeriodId==search.PeriodId))
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
        public ActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper , ActualProductionValidator actualProductionValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualProductionValidator = actualProductionValidator;
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

      
    }
}
