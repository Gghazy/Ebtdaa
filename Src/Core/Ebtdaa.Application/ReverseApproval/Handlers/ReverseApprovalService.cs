using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.ReverseApproval.Dtos;
using Ebtdaa.Application.ReverseApproval.Interfaces;
using Ebtdaa.Common.Dtos;
using Ebtdaa.Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReverseApproval.Handlers
{
    public class ReverseApprovalService : IReverseApprovalService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public ReverseApprovalService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ReverseApprovalResultDto>> UpdateAsync(ReverseApprovalRequestDto request)
        {
            var getFactory = await _dbContext.Factories.FirstOrDefaultAsync(f => f.CommercialRegister == request.CommericalRegistration);
            if (getFactory != null) 
            {
                var checkFactory = await _dbContext.FactoryUpdateStatuses.FirstOrDefaultAsync(f => f.FactoryId == getFactory.Id && f.PeriodId == request.periodId);
                if (checkFactory != null)
                {
                    checkFactory.UpdateStatus = false;
                }
                await _dbContext.SaveChangesAsync();

                return new BaseResponse<ReverseApprovalResultDto>
                {
                    Data = _mapper.Map<ReverseApprovalResultDto>(checkFactory)
                };
            }
            else
            {
                return new BaseResponse<ReverseApprovalResultDto>
                {
                    Data = _mapper.Map<ReverseApprovalResultDto>(getFactory)
                };
            }
        }
    }
}
