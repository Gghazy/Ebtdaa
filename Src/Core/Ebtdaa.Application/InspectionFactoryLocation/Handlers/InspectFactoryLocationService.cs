using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionFactoryContact.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
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
            var notExist = new InspectFactoryLocationResDto();
            notExist.IsCityCorrect = true;
            notExist.IsFactoryEntityCorrect = true;
            notExist.IsWebSiteCorrect = true;
            notExist.IsIndustrialAreaCorrect = true;

            var inspectResult = _dbContext.InspectFactoryLocations
                .Where(i => i.FactoryId == factoryId 
                && i.PeriodId == periodId && i.CreatedBy == ownerIdentity).FirstOrDefault();
            if (inspectResult != null) 
            {
                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = inspectResult != null ? _mapper.Map<InspectFactoryLocationResDto>(inspectResult) : notExist
                };
            }
            else
            {
                var resualt = await _dbContext.FactoryLocations
                    .Where(x => x.FactoryId == factoryId && x.PeriodId == periodId && x.CreatedDate.Year == DateTime.Now.Year)
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
                    .FirstOrDefaultAsync();

                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = resualt != null ? _mapper.Map<InspectFactoryLocationResDto>(resualt) : notExist
                };
            }
            
        }

        public async Task<BaseResponse<InspectFactoryLocationResDto>> AddAsync(InspectFactoryLocationReqDto req)
        {
            try
            {
                var factoryLocation = _mapper.Map<InspectFactoryLocation>(req);
                factoryLocation.CityId = factoryLocation.CityId == -1 ? null : factoryLocation.CityId;
                factoryLocation.IndustrialAreaId = factoryLocation.IndustrialAreaId == -1 ? null : factoryLocation.IndustrialAreaId;
                factoryLocation.FactoryEntityId = factoryLocation.FactoryEntityId == -1 ? null : factoryLocation.FactoryEntityId;


                await _dbContext.InspectFactoryLocations.AddAsync(factoryLocation);

                await _dbContext.SaveChangesAsync();

                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = _mapper.Map<InspectFactoryLocationResDto>(factoryLocation),
                    IsSuccess=true
                };
            }catch (Exception ex)
            {
                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data =new  InspectFactoryLocationResDto(),
                    IsSuccess = false
                };
            }
        }

        public async Task<BaseResponse<InspectFactoryLocationResDto>> UpdateAsync(InspectFactoryLocationReqDto req)
        {
            try
            {
                req.CityId = req.CityId == -1 ? null : req.CityId;
                req.IndustrialAreaId = req.IndustrialAreaId == -1 ? null : req.IndustrialAreaId;
                req.FactoryEntityId = req.FactoryEntityId == -1 ? null : req.FactoryEntityId;

                var factoryLocation = await _dbContext.InspectFactoryLocations.FirstOrDefaultAsync(x => x.Id == req.Id);
                var factoryLocationUpdated = _mapper.Map(req, factoryLocation);


                await _dbContext.SaveChangesAsync();

                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = _mapper.Map<InspectFactoryLocationResDto>(factoryLocationUpdated)
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<InspectFactoryLocationResDto>
                {
                    Data = new InspectFactoryLocationResDto(),
                    IsSuccess = false
                };
            }
        }
    }
}
