using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Application.FactoriesUpdateStatus.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoriesUpdateStatus.Handlers
{
    public class FactoryUpdateStatusService : IFactoryUpdateStatusService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        public FactoryUpdateStatusService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<FactUpdateStatusResultDto>> AddAsync(FactUpdateStatusRequestDto req)
        {
            var factoryUpdateStatus = _mapper.Map<FactoryUpdateStatus>(req);
            
            await _dbContext.FactoryUpdateStatuses.AddAsync(factoryUpdateStatus);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<FactUpdateStatusResultDto>
            {
                Data = _mapper.Map<FactUpdateStatusResultDto>(factoryUpdateStatus)
            };
        }

        public async Task<BaseResponse<FactUpdateStatusResultDto>> UpdateAsync(FactUpdateStatusRequestDto req)
        {
            var factoryStatus = await _dbContext.FactoryUpdateStatuses.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryStatustUpdated = _mapper.Map(req, factoryStatus);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<FactUpdateStatusResultDto>
            {
                Data = _mapper.Map<FactUpdateStatusResultDto>(factoryStatustUpdated)
            };
        }

        public async Task<BaseResponse<FactUpdateStatusResultDto>> GetOne(int factoryId, int periodId)
        {
            var resualt = await _dbContext.FactoryUpdateStatuses.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            return new BaseResponse<FactUpdateStatusResultDto>
            {
                Data = resualt != null ? _mapper.Map<FactUpdateStatusResultDto>(resualt) : new FactUpdateStatusResultDto()
            };
        }
    }
}
