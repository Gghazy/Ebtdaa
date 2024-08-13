using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Ebtdaa.Application.FactoryContacts.Validation;
using Ebtdaa.Domain.Factories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;

namespace Ebtdaa.Application.FactoryContacts.Handlers
{
    public class FactoryContactService : IFactoryContactService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryContactValidator _validator;
        private readonly IScreenStatusService _screenStatusService;

        public FactoryContactService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryContactValidator validator, IScreenStatusService screenStatusService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
        }
        public async Task<BaseResponse<FactoryContactResultDto>> GetOne(int factoryId , int periodId)
        {
            var resualt = await _dbContext.FactoryContacts
                .Include(x=>x.FinanceManagerPhone)
                .Include(x=>x.OfficerPhone)
                .Include(x=>x.ProductionManagerPhone)
                .FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            return new BaseResponse<FactoryContactResultDto>
            {
                Data =resualt!=null? _mapper.Map<FactoryContactResultDto>(resualt):new FactoryContactResultDto()
            };
        }
        public async Task<BaseResponse<FactoryContactResultDto>> AddAsync(FactoryContactRequestDto req)
        {
            var factoryContact = _mapper.Map<FactoryContact>(req);

            // Validation
            var result = await _validator.ValidateAsync(factoryContact);
            if (result.IsValid == false) throw new ValidationException(result.Errors);


            await _dbContext.FactoryContacts.AddAsync(factoryContact);

            ///
            /*var allPeriods = await _dbContext.Periods
                      .Include(x => x.FactoryUpdateStatuses)
                      .Where(r => r.FactoryUpdateStatuses.
                      All(x => x.FactoryId == req.FactoryId)).Select(i => i.Id)
                      .ToListAsync();*/
            var allPeriods = await _dbContext.Periods
                   .Where(x => x.PeriodStartDate.Year == DateTime.Now.Year)
                   .Select(i => i.Id)
                   .ToListAsync();

            var AllPeriodsHasData = await _dbContext.FactoryContacts
                            .Where(x => x.FactoryId == req.FactoryId &&
                            x.CreatedDate.Year == DateTime.Now.Year &&
                            allPeriods.Contains(x.PeriodId))
                            .Select(x => x.PeriodId).ToListAsync();

            AllPeriodsHasData.Add(req.PeriodId);

            var emptyPeriods = allPeriods.Except(AllPeriodsHasData).ToList();
            foreach (var item in emptyPeriods)
            {
                var newFactoryFile = new FactoryContact();
                newFactoryFile.OfficerPhoneId = factoryContact.OfficerPhoneId;
                newFactoryFile.OfficerEmail = factoryContact.OfficerEmail;
                newFactoryFile.ProductionManagerPhoneId = factoryContact.ProductionManagerPhoneId;
                newFactoryFile.ProductionManagerEmail = factoryContact.ProductionManagerEmail;
                newFactoryFile.FinanceManagerPhoneId = factoryContact.FinanceManagerPhoneId;
                newFactoryFile.FinanceManagerEmail = factoryContact.FinanceManagerEmail;
                newFactoryFile.OfficerPhone = factoryContact.OfficerPhone;
                newFactoryFile.FinanceManagerPhone = factoryContact.FinanceManagerPhone;
                newFactoryFile.ProductionManagerPhone = factoryContact.ProductionManagerPhone;


                newFactoryFile.FactoryId = factoryContact.FactoryId;
                newFactoryFile.PeriodId = item;

                await _dbContext.FactoryContacts.AddAsync(newFactoryFile);
            }
            ///

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryContactResultDto>
            {
                Data = _mapper.Map<FactoryContactResultDto>(factoryContact)
            };
        }
        public async Task<BaseResponse<FactoryContactResultDto>> UpdateAsync(FactoryContactRequestDto req)
        {
            var factoryContact = await _dbContext.FactoryContacts.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryContactUpdated = _mapper.Map(req, factoryContact);

            // Validation
            var result = await _validator.ValidateAsync(factoryContactUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactoryContactResultDto>
            {
                Data = _mapper.Map<FactoryContactResultDto>(factoryContactUpdated)
            };
        }

        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            var result = await _dbContext.FactoryContacts
                                     .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                                     .ToListAsync();
            _dbContext.FactoryContacts.RemoveRange(result);

            return new BaseResponse<bool>
            {
                Data = true
            };
        }
    }
}
