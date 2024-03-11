using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryFinancials.Handlers
{
    public class FactoryFinancialService : IFactoryFinancialService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryFinancialValidator _validator;
        private readonly IScreenStatusService _screenStatusService;

        public FactoryFinancialService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryFinancialValidator validator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
        }

        public async Task<BaseResponse<FactoryFinancialResultDto>> GetOne(int id,int year)
        {
            var resualt = await _dbContext.FactoryFinancials.FirstOrDefaultAsync(x => x.FactoryId == id&&x.Year==year);

            return new BaseResponse<FactoryFinancialResultDto>
            {
                Data = resualt != null ? _mapper.Map<FactoryFinancialResultDto>(resualt) : new FactoryFinancialResultDto()
            };
        }
        public async Task<BaseResponse<FactoryFinancialResultDto>> AddAsync(FactoryFinancialRequestDto req)
        {
            var factoryFinancial = _mapper.Map<FactoryFinancial>(req);

            // Validation
            var result = await _validator.ValidateAsync(factoryFinancial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryFinancials.AddAsync(factoryFinancial);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<FactoryFinancialResultDto>
            {
                Data = _mapper.Map<FactoryFinancialResultDto>(factoryFinancial)
            };
        }
        public async Task<BaseResponse<FactoryFinancialResultDto>> UpdateAsync(FactoryFinancialRequestDto req)
        {
            var factoryFinancial = await _dbContext.FactoryFinancials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryFinancialUpdated = _mapper.Map(req, factoryFinancial);

            // Validation
            var result = await _validator.ValidateAsync(factoryFinancialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<FactoryFinancialResultDto>
            {
                Data = _mapper.Map<FactoryFinancialResultDto>(factoryFinancialUpdated)
            };
        }
    }
}
