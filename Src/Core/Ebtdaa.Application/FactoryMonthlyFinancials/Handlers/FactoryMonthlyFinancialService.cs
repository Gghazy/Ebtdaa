using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.FactoryMonthlyFinancials.Dtos;
using Ebtdaa.Application.FactoryMonthlyFinancials.Interfaces;
using Ebtdaa.Application.FactoryMonthlyFinancials.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.FactoryMonthlyFinancials.Handlers
{
    public class FactoryMonthlyFinancialService : IFactoryMonthlyFinancialService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryMonthlyFinancialValidator _validator;
        private readonly IScreenStatusService _screenStatusService;


        public FactoryMonthlyFinancialService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryMonthlyFinancialValidator validator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
        }

        public async Task<BaseResponse<FactoryMonthlyFinancialResultDto>> GetOne(int id, int periodId)
        {
            var resualt = await _dbContext.FactoryMonthlyFinancials.FirstOrDefaultAsync(x => x.FactoryId == id && x.PeriodId == periodId);

            return new BaseResponse<FactoryMonthlyFinancialResultDto>
            {
                Data = resualt != null ? _mapper.Map<FactoryMonthlyFinancialResultDto>(resualt) : new FactoryMonthlyFinancialResultDto()
            };
        }
        public async Task<BaseResponse<FactoryMonthlyFinancialResultDto>> AddAsync(FactoryMonthlyFinancialRequestDto req)
        {
            var factoryFinancial = _mapper.Map<FactoryMonthlyFinancial>(req);

            // Validation
            var result = await _validator.ValidateAsync(factoryFinancial);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryMonthlyFinancials.AddAsync(factoryFinancial);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<FactoryMonthlyFinancialResultDto>
            {
                Data = _mapper.Map<FactoryMonthlyFinancialResultDto>(factoryFinancial)
            };
        }



        public async Task<BaseResponse<FactoryMonthlyFinancialResultDto>> UpdateAsync(FactoryMonthlyFinancialRequestDto req)
        {
            var factoryFinancial = await _dbContext.FactoryMonthlyFinancials.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryFinancialUpdated = _mapper.Map(req, factoryFinancial);

            // Validation
            var result = await _validator.ValidateAsync(factoryFinancialUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<FactoryMonthlyFinancialResultDto>
            {
                Data = _mapper.Map<FactoryMonthlyFinancialResultDto>(factoryFinancialUpdated)
            };
        }
    }
}
