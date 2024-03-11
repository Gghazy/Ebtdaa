using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Ebtdaa.Application.FactoryContacts.Dtos;
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
        public async Task<BaseResponse<FactoryContactResultDto>> GetOne(int factoryId)
        {
            var resualt = await _dbContext.FactoryContacts
                .Include(x=>x.FinanceManagerPhone)
                .Include(x=>x.OfficerPhone)
                .Include(x=>x.ProductionManagerPhone)
                .FirstOrDefaultAsync(x => x.FactoryId == factoryId);

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


    }
}
