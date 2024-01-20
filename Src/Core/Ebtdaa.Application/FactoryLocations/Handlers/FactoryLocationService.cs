using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Handlers
{
    public class FactoryLocationService : IFactoryLocationService
    {

        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryLocationValidator _validator;

        public FactoryLocationService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryLocationValidator validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> GetOne(int id)
        {
            var resualt = await _dbContext.FactoryLocations.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<FactoryLocationResultDto>
            {
                Data = resualt!=null? _mapper.Map<FactoryLocationResultDto>(resualt):new FactoryLocationResultDto()
            };
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> AddAsync(FactoryLocationRequestDto req)
        {
            var factoryLocation = _mapper.Map<FactoryLocation>(req);

            // Validation
            var result = await _validator.ValidateAsync(factoryLocation);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.FactoryLocations.AddAsync(factoryLocation);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryLocationResultDto>
            {
                Data = _mapper.Map<FactoryLocationResultDto>(factoryLocation)
            };
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> UpdateAsync(FactoryLocationRequestDto req)
        {
            var factoryLocation = await _dbContext.FactoryLocations.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryLocationUpdated = _mapper.Map(req, factoryLocation);

            // Validation
            var result = await _validator.ValidateAsync(factoryLocationUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryLocationResultDto>
            {
                Data = _mapper.Map<FactoryLocationResultDto>(factoryLocationUpdated)
            };
        }
    }
}
