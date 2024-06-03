using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Application.FactoriesUpdateStatus.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            factoryUpdateStatus.EnteredAt = DateTime.Now;
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
            if (factoryStatus.DataStatus==Ebtdaa.Common.Enums.DataStatus.Added)
            {
                factoryStatus.DataStatus = Ebtdaa.Common.Enums.DataStatus.Reviwed;
                factoryStatus.ReviewedAt = DateTime.Now;

            }
            else if (factoryStatus.DataStatus == Ebtdaa.Common.Enums.DataStatus.Reviwed)
            {
                factoryStatus.DataStatus = Ebtdaa.Common.Enums.DataStatus.Approved;
                factoryStatus.ApprovedAt = DateTime.Now;

            }


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

        public async Task<BaseResponse<FactoryIdentitesResultDto>> CheckFactoryStatus(int factoryId, int periodId,string userId)
        {
            var result = await _dbContext.BasicFactoryInfos
                .FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);
            var statusResult = new FactoryIdentitesResultDto();
            if(result.DataEntry == userId)
            {
                statusResult.DataStatus = DataStatus.Added;
                statusResult.CurrentDataStatus = DataStatus.NotApproved;
                statusResult.StatusButton ="إدخال";

            }
            if (result.DataReviewer == userId)
            {
                statusResult.DataStatus = DataStatus.Reviwed;
                statusResult.CurrentDataStatus = DataStatus.Added;
                statusResult.StatusButton = "مراجعة";
            }
            if (result.DataApprover == userId)
            {
                statusResult.DataStatus = DataStatus.Approved;
                statusResult.CurrentDataStatus = DataStatus.Reviwed;
                statusResult.StatusButton = "إعتماد المسح";
            }
            
            if (result.DataEntry == userId && result.DataReviewer == userId && result.DataApprover == userId)
            {
                statusResult.DataStatus = DataStatus.Approved;
                statusResult.CurrentDataStatus = DataStatus.NotApproved;
                statusResult.StatusButton = "إعتماد المسح";
            }

            if (result.DataEntry == userId && result.DataApprover == userId && result.DataReviewer != userId)
            {
                statusResult.DataStatus = DataStatus.Added;
                statusResult.CurrentDataStatus = DataStatus.NotApproved;
                statusResult.StatusButton = "إدخال";
            }
            
           
            return new BaseResponse<FactoryIdentitesResultDto>
            {
                Data = statusResult
            };

        }
    }
}
