using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Interfaces;
using Ebtdaa.Domain.InspectorActualProduction.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Handlers
{
    public class InspectActualProductionService : IInspectActualProductionService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InspectActualProductionResultDto>> GetOne(int factoryId , int periodId , string ownerIdentity)
        {
            var getForInspector = await _dbContext.InspectActualProductions.FirstOrDefaultAsync(x => x.FactoryId==factoryId && x.PeriodId == periodId && x.CreatedBy == ownerIdentity);
             if (getForInspector == null)
             {
                var result = await _dbContext.ActualProductionAndCapacities
                                         .FirstOrDefaultAsync(x => x.PeriodId == periodId);
                var map = new InspectActualProductionResultDto()
                {
                    Id = result.Id,
                    ActualProductionUintId = result.ActualProductionUintId,
                    ActualProduction = result.ActualProduction,
                    DesignedCapacity = result.DesignedCapacity,
                    DesignedCapacityUnitId = result.DesignedCapacityUnitId,
                    FactoryId = factoryId,
                    PeriodId = periodId,
                    FactoryProductId = result.FactoryProductId
                };
                var response = _mapper.Map<InspectActualProductionResultDto>(map);

                return new BaseResponse<InspectActualProductionResultDto>
                {
                    Data = map != null ? response : new InspectActualProductionResultDto()
                };
             }
            else
            {
                return new BaseResponse<InspectActualProductionResultDto>
                {
                    Data = _mapper.Map<InspectActualProductionResultDto>(getForInspector) 
                };
            }
        }

        public async Task<BaseResponse<InspectActualProductionResultDto>> AddAsync(InspectActualProductionReqDto request)
        {
            var actualProduction = _mapper.Map<InspectActualProduction>(request);

            await _dbContext.InspectActualProductions.AddAsync(actualProduction);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectActualProductionResultDto>
            {
                Data = _mapper.Map<InspectActualProductionResultDto>(actualProduction)
            };
        }

        public async Task<BaseResponse<InspectActualProductionResultDto>> UpdateAsync(InspectActualProductionReqDto request)
        {
            var getActualproduction = await _dbContext.InspectActualProductions.FirstOrDefaultAsync(a => a.Id == request.Id);
            var actualproductionUpdated = _mapper.Map(request, getActualproduction);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<InspectActualProductionResultDto>
            {
                Data = _mapper.Map<InspectActualProductionResultDto>(actualproductionUpdated)
            };
        }
    }
}
