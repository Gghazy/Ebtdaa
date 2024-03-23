using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Interfaces;
using Ebtdaa.Application.InspectionBasicFactInfos.Validation;
using Ebtdaa.Domain.InspectorBasicFactoryInfo.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Handlers
{
    public class InspectBasicFactInfoService : IInspectBasicFactInfoService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly InspectBasicDataValidator _validations;
        public InspectBasicFactInfoService(IEbtdaaDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InspectBasicFactInfoResultDto>> GetOne(int factoryId, int periodId , string OwnerIdentity)
        {
            var checkIsExist = await _dbContext.InspectBasicFactoryInfos.FirstOrDefaultAsync(i => i.FactoryId == factoryId && i.PeriodId == periodId && i.OwnerIdentity == OwnerIdentity);
            if (checkIsExist == null)
            {
                var resualt = await _dbContext.Factories
                               .Include(x => x.BaiscFactoryInfos)
                               .FirstOrDefaultAsync(x => x.Id == factoryId);
                if (resualt.BaiscFactoryInfos != null)
                {

                    var basicinfo = resualt.BaiscFactoryInfos.FirstOrDefault(x => x.PeriodId == periodId);
                    if (basicinfo != null)
                    {
                        resualt.Status = basicinfo.FactoryStatusId;
                    }

                }
                return new BaseResponse<InspectBasicFactInfoResultDto>
                {
                    Data = _mapper.Map<InspectBasicFactInfoResultDto>(resualt)
                };
            }
            else
            {
                return new BaseResponse<InspectBasicFactInfoResultDto>
                {
                    Data = _mapper.Map<InspectBasicFactInfoResultDto>(checkIsExist)
                };
            }
        }
        public async Task<BaseResponse<InspectBasicFactInfoResultDto>> AddAsync(InspectBasicFactInfoRequestDto req)
        {
            var inspectBasicFactory = _mapper.Map<InspectBasicFactoryInfo>(req);

            // Validation
            var result = await _validations.ValidateAsync(inspectBasicFactory);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.InspectBasicFactoryInfos.AddAsync(inspectBasicFactory);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectBasicFactInfoResultDto>
            {
                Data = _mapper.Map<InspectBasicFactInfoResultDto>(inspectBasicFactory)
            };
        }
        public async Task<BaseResponse<InspectBasicFactInfoResultDto>> UpdateAsync(InspectBasicFactInfoRequestDto req)
        {
            var inspectFact = await _dbContext.InspectBasicFactoryInfos.FirstOrDefaultAsync(x => x.Id == req.Id);
            var inspectFactUpdated = _mapper.Map(req, inspectFact);

            //// Validation
            var result = await _validations.ValidateAsync(inspectFactUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectBasicFactInfoResultDto>
            {
                Data = _mapper.Map<InspectBasicFactInfoResultDto>(inspectFactUpdated)
            };
            
           
            
        }
    }
}
