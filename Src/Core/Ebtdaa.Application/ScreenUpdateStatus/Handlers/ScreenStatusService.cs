using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.ScreenStatus.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ScreenUpdateStatus.Handlers
{
    public class ScreenStatusService : IScreenStatusService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public ScreenStatusService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ScreenStatusResultDto>>> GetAll( int periodId , int factoryId)
        {
            var respose = _mapper.Map<List<ScreenStatusResultDto>>(await _dbContext.ScreenStatuses.Where(x=> x.PeriodId == periodId && x.FactoryId == factoryId).ToListAsync());

            return new BaseResponse<List<ScreenStatusResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> AddAsync(ScreenStatusRequestDto req)
        {
            var screenStatus = _mapper.Map<ScreenStatus>(req);
           
            await _dbContext.ScreenStatuses.AddAsync(screenStatus);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> UpdateAsync(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses.FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId);
            var screenStatusUpdated = _mapper.Map(req, screenStatus);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        } 
        public async Task<BaseResponse<ScreenStatusResultDto>> ReverseApproval(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses.FirstOrDefaultAsync(x => x.FactoryId == req.FactoryId && x.PeriodId == req.PeriodId);
            var screenStatusUpdated = _mapper.Map(req, screenStatus);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        }
    }
}
