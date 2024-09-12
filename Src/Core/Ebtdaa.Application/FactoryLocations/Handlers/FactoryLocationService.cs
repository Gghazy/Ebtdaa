using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Common.Enums;
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
        private readonly FactoryLocationAttachmentValidator _validatorAttachment;
        private readonly IScreenStatusService _screenStatusService;
        private readonly IFactoryLocationAttachmentService _factoryLocationAttachmentService;

        public FactoryLocationService(IEbtdaaDbContext dbContext, IMapper mapper, FactoryLocationValidator validator, IScreenStatusService screenStatusService, FactoryLocationAttachmentValidator validatorAttachment, IFactoryLocationAttachmentService factoryLocationAttachmentService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
            _screenStatusService = screenStatusService;
            _validatorAttachment = validatorAttachment;
            _factoryLocationAttachmentService = factoryLocationAttachmentService;
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> GetOne(int factoryId , int periodId)
        {
            var resualt = await _dbContext.FactoryLocations.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            return new BaseResponse<FactoryLocationResultDto>
            {
                Data = resualt!=null? _mapper.Map<FactoryLocationResultDto>(resualt):new FactoryLocationResultDto()
            };
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> AddAsync(FactoryLocationRequestDto req)
        {
            try
            {
                var factoryLocation = _mapper.Map<FactoryLocation>(req);

                // Validation
                var result = await _validator.ValidateAsync(factoryLocation);
                if (result.IsValid == false) throw new ValidationException(result.Errors);
                await _dbContext.FactoryLocations.AddAsync(factoryLocation);


                ///
                /* var allPeriods = await _dbContext.Periods
                       .Include(x => x.FactoryUpdateStatuses)
                       .Where(r => r.FactoryUpdateStatuses.
                       All(x => x.FactoryId == req.FactoryId)).Select(i => i.Id)
                       .ToListAsync();*/
                var allBasicFactory = await _dbContext.BasicFactoryInfos
                     .Where(x => x.FactoryId == req.FactoryId && x.FactoryStatusId != FactoryStatusEnum.Canceled)
                     .Select(i => i.PeriodId)
                     .ToListAsync(); 

                var allPeriods = await _dbContext.Periods
                                        // .Where(x=>x.PeriodStartDate.Year == DateTime.Now.Year && allBasicFactory.Contains(x.Id))
                .Where(x =>  allBasicFactory.Contains(x.Id))

                    .Select(i => i.Id)
                    .ToListAsync();



                var AllPeriodsHasData = await _dbContext.FactoryLocations
                                .Where(x => x.FactoryId == req.FactoryId &&
                                x.CreatedDate.Year == DateTime.Now.Year &&
                                allPeriods.Contains(x.PeriodId))
                                .Select(x => x.PeriodId).ToListAsync();

                AllPeriodsHasData.Add(req.PeriodId);

                var emptyPeriods = allPeriods.Except(AllPeriodsHasData).ToList();

                foreach (var item in emptyPeriods)
                {
                    var newFactoryFile = new FactoryLocation();
                    newFactoryFile.IndustrialAreaId = factoryLocation.IndustrialAreaId;
                    newFactoryFile.FactoryId = factoryLocation.FactoryId;
                    newFactoryFile.CityId = factoryLocation.CityId;
                    newFactoryFile.FactoryEntityId = factoryLocation.FactoryEntityId;
                    newFactoryFile.WebSite = factoryLocation.WebSite;

                    newFactoryFile.PeriodId = item;

                    await _dbContext.FactoryLocations.AddAsync(newFactoryFile);
                }


                ///

                await _dbContext.SaveChangesAsync();

                return new BaseResponse<FactoryLocationResultDto>
                {
                    Data = _mapper.Map<FactoryLocationResultDto>(factoryLocation),
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FactoryLocationResultDto>
                {
                    Data = new FactoryLocationResultDto(),
                    IsSuccess = false
                };

            }
        
        }
        public async Task<BaseResponse<FactoryLocationResultDto>> UpdateAsync(FactoryLocationRequestDto req)
        {
            try
            {
                var factoryLocation = await _dbContext.FactoryLocations.FirstOrDefaultAsync(x => x.Id == req.Id);
                var factoryLocationUpdated = _mapper.Map(req, factoryLocation);

                // Validation
                var result = await _validator.ValidateAsync(factoryLocationUpdated);
                if (result.IsValid == false) throw new ValidationException(result.Errors);

                await _dbContext.SaveChangesAsync();

                return new BaseResponse<FactoryLocationResultDto>
                {
                    Data = _mapper.Map<FactoryLocationResultDto>(factoryLocationUpdated),
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<FactoryLocationResultDto>
                {
                    Data = new FactoryLocationResultDto(),
                    IsSuccess = false
                };

            }
        }
        public async Task<BaseResponse<bool>> DeleteByFactoryIdAndPeriodId(int factoryId, int periodId)
        {
            try
            {
                var result = await _dbContext.FactoryLocations
                                         .Where(x => x.PeriodId == periodId && x.FactoryId == factoryId)
                                         .ToListAsync();
                if(result.Count>0)
                    _dbContext.FactoryLocations.RemoveRange(result);

                var file = await _dbContext.FactoryLocationAttachments.FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);
                if (file != null)
                    _dbContext.FactoryLocationAttachments.Remove(file);

                await _dbContext.SaveChangesAsync();
                return new BaseResponse<bool>
                {
                    Data = true,
                    IsSuccess=true
                };
            }
            catch   (Exception ex) {
                return new BaseResponse<bool>
                {
                    Data = false,
                    IsSuccess = false
                };
            }
        }
    }
}
