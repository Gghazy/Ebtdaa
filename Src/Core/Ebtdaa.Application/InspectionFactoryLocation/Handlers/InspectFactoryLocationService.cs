using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Interfaces;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ebtdaa.Application.InspectionFactoryLocation.Handlers
{
    public class InspectFactoryLocationService : IInspectFactoryLocationService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectFactoryLocationService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InspectFactoryLocationResDto>> GetAll(int factoryId, int periodId, string ownerIdentity)
        {
            var inspectResult = _dbContext.InspectFactoryLocations
                .Where(i => i.FactoryId == factoryId 
                && i.PeriodId == periodId && i.CreatedBy == ownerIdentity).FirstOrDefault();
            if (inspectResult != null) 
            {
                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = inspectResult != null ? _mapper.Map<InspectFactoryLocationResDto>(inspectResult) : new InspectFactoryLocationResDto()
                };
            }
            else
            {
                var resualt = await _dbContext.FactoryLocations
                    .Select(x=> new InspectFactoryLocationResDto
                    {
                         FactoryId=factoryId,
                         PeriodId =periodId,
                         FactoryEntityId =x.FactoryEntityId,
                         CityId =x.CityId,
                         IndustrialAreaId =x.IndustrialAreaId,
                         WebSite =x.WebSite,
                         IsFactoryEntityCorrect =true,
                         IsCityCorrect =true,
                         IsIndustrialAreaCorrect =true,
                         IsWebSiteCorrect =true,
                         NewFactoryEntityId =0,
                         NewCityId =0,
                         NewIndustrialAreaId =0,
                         NewWebSite ="",
                         Comment =""
                    })
                    .FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId==periodId );

                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = resualt != null ? _mapper.Map<InspectFactoryLocationResDto>(resualt) : new InspectFactoryLocationResDto()
                };
            }
            
        }

        public async Task<BaseResponse<InspectFactoryLocationResDto>> AddAsync(InspectFactoryLocationReqDto req)
        {
            var factoryLocation = _mapper.Map<InspectFactoryLocation>(req);

            
            await _dbContext.InspectFactoryLocations.AddAsync(factoryLocation);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectFactoryLocationResDto>
            {
                Data = _mapper.Map<InspectFactoryLocationResDto>(factoryLocation)
            };
        }

        public async Task<BaseResponse<InspectFactoryLocationResDto>> UpdateAsync(InspectFactoryLocationReqDto req)
        {
            var factoryLocation = await _dbContext.InspectFactoryLocations.FirstOrDefaultAsync(x => x.Id == req.Id);
            var factoryLocationUpdated = _mapper.Map(req, factoryLocation);

            
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectFactoryLocationResDto>
            {
                Data = _mapper.Map<InspectFactoryLocationResDto>(factoryLocationUpdated)
            };
        }
    }
}
