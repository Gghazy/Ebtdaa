using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
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

        public ActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper , ActualProductionValidator actualProductionValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _actualProductionValidator = actualProductionValidator;
        }

        public async Task<BaseResponse<ActualProductionResultDto>> GetOne(int Id)
        {
            var result = await _dbContext.ActualProductionAndCapacities.FirstOrDefaultAsync(x => x.Id == Id);

            return new BaseResponse<ActualProductionResultDto>
            {
                Data = result != null ? _mapper.Map<ActualProductionResultDto>(result) : new ActualProductionResultDto()
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
