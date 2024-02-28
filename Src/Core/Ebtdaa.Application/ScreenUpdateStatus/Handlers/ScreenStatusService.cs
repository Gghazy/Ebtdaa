using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.ScreenUpdateStatus.Entity;
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

        public async Task<BaseResponse<ScreenStatusResultDto>> AddAsync(ScreenStatusRequestDto request)
        {
            var screenStatus = _mapper.Map<ScreenStatus>(request);

            await _dbContext.ScreenStatuses.AddAsync(screenStatus);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatus)
            };
        }

        public async Task<BaseResponse<ScreenStatusResultDto>> UpdateAsync(ScreenStatusRequestDto req)
        {
            var screenStatus = await _dbContext.ScreenStatuses.FirstOrDefaultAsync(x => x.Id == req.Id);
            var screenStatusUpdated = _mapper.Map(req, screenStatus);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ScreenStatusResultDto>
            {
                Data = _mapper.Map<ScreenStatusResultDto>(screenStatusUpdated)
            };
        }
    }
    
}
