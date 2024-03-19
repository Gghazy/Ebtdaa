using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.InspectionFactoryContact.Dtos;
using Ebtdaa.Application.InspectionFactoryContact.Interfaces;
using Ebtdaa.Application.InspectionFactoryContact.Validation;
using Ebtdaa.Domain.InpectorFactoryContact.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionFactoryContact.Handlers
{
    public class InspectFactoryContactService : IInspectFactoryContactService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly InspectFactoryContactValidation _validations;

        public InspectFactoryContactService (IEbtdaaDbContext dbContext, IMapper mapper , InspectFactoryContactValidation validations)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validations = validations;
        }

        public async Task<BaseResponse<InspectFactContactResultDto>> GetOne(int factoryId , int periodId,string ownerIdentity)
        {
            var checkIsExist = await _dbContext.InspectFactoryContacts.FirstOrDefaultAsync(i => i.FactoryId == factoryId && i.PeriodId == periodId && i.CreatedBy == ownerIdentity);
            if (checkIsExist == null) 
            {
                var resualt = await _dbContext.FactoryContacts
                .Include(x => x.FinanceManagerPhone)
                .Include(x => x.OfficerPhone)
                .Include(x => x.ProductionManagerPhone)
                .FirstOrDefaultAsync(x => x.FactoryId == factoryId);

                return new BaseResponse<InspectFactContactResultDto>
                {
                    Data = resualt != null ? _mapper.Map<InspectFactContactResultDto>(resualt) : new InspectFactContactResultDto()
                };
            }
            else
            {
               
                return new BaseResponse<InspectFactContactResultDto>
                {
                    Data = checkIsExist != null ? _mapper.Map<InspectFactContactResultDto>(checkIsExist) : new InspectFactContactResultDto()
                };
            }
        }

        public async Task<BaseResponse<InspectFactContactResultDto>> AddAsync(InspectFactContactRequestDto req)
        {
            var factoryContact = _mapper.Map<InspectFactoryContact>(req);

            var result = await _validations.ValidateAsync(factoryContact);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.InspectFactoryContacts.AddAsync(factoryContact);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectFactContactResultDto>
            {
                Data = _mapper.Map<InspectFactContactResultDto>(factoryContact)
            };
        }

        public async Task<BaseResponse<InspectFactContactResultDto>> UpdateAsync(InspectFactContactRequestDto req)
        {
            var factoryContact = await _dbContext.InspectFactoryContacts.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryContactUpdated = _mapper.Map(req, factoryContact);

            // Validation
            var result = await _validations.ValidateAsync(factoryContactUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectFactContactResultDto>
            {
                Data = _mapper.Map<InspectFactContactResultDto>(factoryContactUpdated)
            };
        }
    }
}
