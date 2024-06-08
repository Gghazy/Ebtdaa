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
            var resultStatus = await _dbContext.FactoryUpdateStatuses
                               .FirstOrDefaultAsync(x => x.FactoryId == factoryId && x.PeriodId == periodId);

            var statusResult = new FactoryIdentitesResultDto();
            
            

            if (result == null)
            {

                SetStatus(statusResult, DataStatus.New, DataStatus.NotApproved, "إدخال", false);
            }
            else
            {

                bool isDataEntry = result.DataEntry == userId;
                bool isDataReviewer = result.DataReviewer == userId;
                bool isDataApprover = result.DataApprover == userId;


                if (isDataEntry && isDataReviewer && isDataApprover)
                {
                    SetStatus(statusResult, DataStatus.Approved, DataStatus.NotApproved, "إعتماد المسح", false);
                }
             
                else if (isDataApprover)
                {
                    if (resultStatus.DataStatus == null && isDataEntry)
                    {
                        SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);
                    }
                    else if (resultStatus.DataStatus == DataStatus.Reviwed )
                    {
                        SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Approved, "إعتماد المسح", true);
                    }
                }
                else if (isDataReviewer)
                {
                    if (resultStatus.DataStatus == DataStatus.Reviwed && isDataEntry)
                    {
                        SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);
                    }
                    else if (resultStatus.DataStatus == DataStatus.Reviwed)
                    {

                        SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Added, "مراجعة", true);
                    }
                }
               
            }
          
            


            return new BaseResponse<FactoryIdentitesResultDto>
            {
                Data = statusResult
            };
            
             void SetStatus(FactoryIdentitesResultDto statusResult, DataStatus dataStatus,
              DataStatus currentDataStatus, string statusButton,
              Boolean isDisable
              )
            {
                statusResult.DataStatus = dataStatus;
                statusResult.CurrentDataStatus = currentDataStatus;
                statusResult.StatusButton = statusButton;
                statusResult.isDisable = isDisable;

            }

        }
    }
}
