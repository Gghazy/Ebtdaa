using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.LogIn.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Handlers
{
    public class FactoryService : IFactoryService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly FactoryValidator _factoryValidator;

        public FactoryService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryValidator factoryValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _factoryValidator= factoryValidator;
        }
        public async Task<BaseResponse<QueryResult<FactoryResualtDto>>> GetAll(FactorySearch search)
        {
           
            var resualt = _mapper.Map<QueryResult<FactoryResualtDto>>(await _dbContext.Factories.Where(f => f.OwnerIdentity == search.OwnerIdentity.ToString()).ToQueryResult(search.PageNumber,search.PageSize));


            return new BaseResponse<QueryResult<FactoryResualtDto>>
            {
                Data = resualt
            };

        }
        public async Task<BaseResponse<FactoryResualtDto>> GetOne(int id)
        {
            var resualt = await _dbContext.Factories.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<FactoryResualtDto>
            {
                Data = _mapper.Map<FactoryResualtDto>(resualt)
            };

        }

        public async Task<BaseResponse<FactoryResualtDto>> UpdateAsync(FactoryRequestDto req)
        {
            var factory = await _dbContext.Factories.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryUpdated = _mapper.Map(req, factory);

            // Validation
            var result = await _factoryValidator.ValidateAsync(factoryUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            var basicFactoryInfo = new BasicFactoryInfoRequestDto()
            {
                FactoryId = req.FactoryId,
                PeriodId = req.PeriodId,
                FactoryStatusId = req.Status,
            };
            var mapBasicFactoryInf = _mapper.Map<BaiscFactoryInfo>(basicFactoryInfo);
            await _dbContext.BasicFactoryInfos.AddAsync(mapBasicFactoryInf);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactoryResualtDto>
            {
                Data = _mapper.Map<FactoryResualtDto>(factoryUpdated)
            };
        }

    }
}
