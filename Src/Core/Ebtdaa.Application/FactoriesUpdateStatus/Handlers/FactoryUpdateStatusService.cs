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
            if(factoryStatus!=null)
           if (req.DataStatus == DataStatus.Added)
            {
                factoryStatus.DataStatus = DataStatus.Added;
                factoryStatus.EnteredAt = DateTime.Now;

            }
           else
                if (req.DataStatus==DataStatus.Reviwed)
            {
                factoryStatus.DataStatus = DataStatus.Reviwed;
                factoryStatus.ReviewedAt = DateTime.Now;

            }
            else if (req.DataStatus == DataStatus.Approved)
            {
                factoryStatus.DataStatus = DataStatus.Approved;
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


           
            if (result == null )
            {

                SetStatus(statusResult, DataStatus.New, DataStatus.NotApproved, "إدخال", true);
            }
            else
            {

                bool isDataEntry = (result.DataEntry!=null? result.DataEntry:"") == userId;
                bool isDataReviewer =(result.DataReviewer != null ? result.DataReviewer : "") == userId;
                bool isDataApprover = (result.DataApprover != null ? result.DataApprover : "") == userId;


                if (isDataEntry && isDataReviewer && isDataApprover)
                {
                    if (resultStatus !=null)
                    {
                        if (resultStatus.DataStatus == DataStatus.Approved)
                        {
                            SetStatus(statusResult, DataStatus.Approved, DataStatus.Approved, "تم الإعتماد", true);
                        }
                        else
                            SetStatus(statusResult, DataStatus.Approved, DataStatus.NotApproved, "إعتماد المسح", false);
                    }
                    else
                    {
                        SetStatus(statusResult, DataStatus.Approved, DataStatus.NotApproved, "إعتماد المسح", false);

                    }

                }

               else
            if (isDataApprover)
                {
                    if (resultStatus != null)
                    {
                        if (resultStatus.DataStatus == null && isDataEntry)
                        {
                            SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);
                        }
                        else if (resultStatus.DataStatus == DataStatus.Reviwed)
                        {
                            SetStatus(statusResult, DataStatus.Approved, DataStatus.Reviwed, "إعتماد المسح", false);
                        }
                        else if (resultStatus.DataStatus == DataStatus.Approved)
                        {
                            SetStatus(statusResult, DataStatus.Approved, DataStatus.Approved, "تم الإعتماد", true);
                        }
                        else
                            SetStatus(statusResult, DataStatus.Approved, DataStatus.Approved, "تم الإعتماد", true);
                    }
                    else
                    {
                        if (isDataEntry)
                            SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);
                        else
                           if (isDataReviewer)
                            SetStatus(statusResult, DataStatus.New, DataStatus.New, "لم يتم الإدخال ", true);
                        else
                            SetStatus(statusResult, DataStatus.New, DataStatus.New, "لم يتم الإدخال / المراجعة", true);

                    }

                }
                else if (isDataReviewer)
                {
                    if (resultStatus != null)
                    {
                        if (resultStatus.DataStatus == DataStatus.Added || resultStatus.DataStatus == DataStatus.New && isDataEntry)
                        {
                            SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Added, "مراجعة", false);
                        }
                        else
                      if (resultStatus.DataStatus == DataStatus.Added)
                        {
                            SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Added, "مراجعة", false);
                        }
                        if (resultStatus.DataStatus == DataStatus.New)
                        {
                            SetStatus(statusResult, DataStatus.New, DataStatus.New, "لم يتم الإدخال", true);
                        }
                        else if (resultStatus.DataStatus == DataStatus.Reviwed)
                        {

                            SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Reviwed, "تمت المراجعة", true);
                        }
                        else
                            SetStatus(statusResult, DataStatus.Reviwed, DataStatus.Reviwed, "تمت المراجعة", true);
                    }
                    else
                    {
                        if (isDataEntry)
                            SetStatus(statusResult, DataStatus.Reviwed, DataStatus.New, "مراجعة", false);
                        else
                            SetStatus(statusResult, DataStatus.New, DataStatus.New, "لم يتم الإدخال", true);
                    }
                }
                else if (isDataEntry)
                {
                    if (resultStatus != null)
                    {
                        if (resultStatus.DataStatus == DataStatus.New || resultStatus.DataStatus == null)
                        {
                            SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);
                        }
                        else
                        {
                            SetStatus(statusResult, DataStatus.Added, DataStatus.Added, "تم الإدخال", true);
                        }

                    }
                    else
                        SetStatus(statusResult, DataStatus.Added, DataStatus.New, "إدخال", false);

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
        public async Task<BaseResponse<List<FactUpdateStatusResultDto>>> CheckFactoryUpdateStatus()
        {
            var status = false;
            var result = new List< FactUpdateStatusResultDto>();
            var getPeriods =  _dbContext.Periods.ToList();
            getPeriods.ForEach(p =>
            {
                var isUpdatedData = _dbContext.FactoryUpdateStatuses.Where(f =>  f.PeriodId == p.Id).ToList();
                if(isUpdatedData == null)
                {
                    status = false;
                }
                else
                { 
                    if (isUpdatedData.Any())
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            });
           var factoryData = _dbContext.Factories
                    .Include(x => x.FactoryLocations)
                    .ThenInclude(x => x.City)
                    .ToList();
            foreach (var item in factoryData)
            {
                var getApproverDate = _dbContext.FactoryUpdateStatuses
                    .OrderByDescending(d => d.Id).FirstOrDefault(d => d.FactoryId == item.Id);

                if (getApproverDate != null)
                {
                    var FactUpdateData = new FactUpdateStatusResultDto {
                        UpdatedDate = getApproverDate.CreatedDate,
                        FactoryUpdateStatus = status,
                        FactoryId = item.Id,
                        CityNameAr = item.FactoryLocations.Any() ? item.FactoryLocations.FirstOrDefault().City.NameAr : "",
                        NameAr = item.NameAr,
                        CommercialRegister = item.CommercialRegister
                    };
                    result.Add(FactUpdateData);

                }
                else
                {
                    var FactUpdateData = new FactUpdateStatusResultDto
                    {
                     FactoryUpdateStatus = status,
                    FactoryId = item.Id,

                    CityNameAr = item.FactoryLocations.Any() ? item.FactoryLocations.FirstOrDefault().City.NameAr : "",
                    NameAr = item.NameAr,
                    CommercialRegister = item.CommercialRegister,
                };
                    result.Add(FactUpdateData);
                }

            }
            result.OrderByDescending(d => d.FactoryId)
                    .ToList();
            return new BaseResponse<List<FactUpdateStatusResultDto>>
            { 
                Data = result
            }; 
        }
    }
}
