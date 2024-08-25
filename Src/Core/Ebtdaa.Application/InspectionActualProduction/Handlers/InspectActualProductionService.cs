using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Interfaces;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.InspectorActualProduction.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Handlers
{
    public class InspectActualProductionService : IInspectActualProductionService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public InspectActualProductionService(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<InspectActualProductionResultDto>>> GetAll(int factoryId, int periodId, string OwnerIdentity)
        {
            var getInspectData = await _dbContext.InspectActualProductions
                          .Include(x => x.FactoryProduct)
                          .ThenInclude(x=>x.Product)
                          .Where(i => i.FactoryId == factoryId
                                          && i.PeriodId == periodId && i.CreatedBy==OwnerIdentity)
                          .Select(x => new InspectActualProductionResultDto()
                          {
                              Id=x.Id,
                              ActualProductionUintId = x.ActualProductionUintId ,
                              ActualProduction = x.ActualProduction ?? 0,
                              DesignedCapacity = x.DesignedCapacity ?? 0,
                              DesignedCapacityUnitId = x.DesignedCapacityUnitId ,
                              ActualProductionUintName = x.ActualProductionUint.Name,
                              DesignedCapacityUnitName = x.DesignedCapacityUnit.Name,
                              FactoryId = x.FactoryId,
                              PeriodId = x.PeriodId,
                              FactoryProductId = x.FactoryProductId,
                              InspectAcuProductName = x.InspectAcuProductName,
                              IsActualProductionCorrect = x.IsActualProductionCorrect,
                              IsDesignedCapacityCorrect = x.IsDesignedCapacityCorrect,
                              CorrectActualProduction = x.CorrectActualProduction??0,
                              CorrectDesignedCapacity = x.CorrectDesignedCapacity??0,
                              IsIncreaseReasonCorrect = x.IsIncreaseReasonCorrect,
                              IncreaseReasonCorrect = x.IncreaseReasonCorrect ?? 0,
                              IncreaseReasonId =x.IncreaseReasonId,
                              ActualProductionWeight = x.ActualProductionWeight ?? 0,
                              IncreaseReason = "",
                              Comments = x.Comments,
                          })
                    
                          .ToListAsync();
          
        

            if (getInspectData.Count == 0)
            {
                var result = await _dbContext.ActualProductionAndCapacities
                    .Include(x => x.FactoryProduct)
                    .Where(x => x.FactoryProduct.FactoryId == factoryId && x.PeriodId == periodId)
                    .Select(x => new InspectActualProductionResultDto()
                    {
                        ActualProductionUintId = x.ActualProductionUintId ?? 0,
                        ActualProduction = x.ActualProduction ?? 0,
                        DesignedCapacity = x.DesignedCapacity ?? 0,
                        DesignedCapacityUnitId = x.DesignedCapacityUnitId ?? 0,
                        ActualProductionUintName = x.ActualProductionUint.Name,
                        DesignedCapacityUnitName = x.DesignedCapacityUnit.Name,
                        FactoryId = factoryId,
                        PeriodId = periodId,
                        FactoryProductId = x.FactoryProductId,
                        InspectAcuProductName = x.AcuProductName,
                        IsActualProductionCorrect=true,
                        IsDesignedCapacityCorrect=true,
                        CorrectActualProduction=0,
                        CorrectDesignedCapacity=0,
                        IsIncreaseReasonCorrect=true,
                        IncreaseReasonCorrect=0,
                        IncreaseReasonId=0,
                        ActualProductionWeight= x.FactoryProduct.Product.Kilograms_Per_Unit??0,
                        IncreaseReason="",
                        Comments="",
                    })
                    .ToListAsync();


                var response = _mapper.Map< List<InspectActualProductionResultDto>>(result);

                return new BaseResponse<List<InspectActualProductionResultDto>>
                {
                    Data =  response
                };

            }

            else
            {
                var Inspectresponse = _mapper.Map<List<InspectActualProductionResultDto>>(getInspectData);

                return new BaseResponse<List<InspectActualProductionResultDto>>
                {
                    Data = Inspectresponse
                };
            }
        }
          

        public async Task<BaseResponse<InspectActualProductionResultDto>> AddAsync(InspectActualProductionReqDto request)
        {
            var actualProduction = _mapper.Map<InspectActualProduction>(request);

            await _dbContext.InspectActualProductions.AddAsync(actualProduction);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectActualProductionResultDto>
            {
                Data = _mapper.Map<InspectActualProductionResultDto>(actualProduction)
            };
        }

        public async Task<BaseResponse<InspectActualProductionResultDto>> UpdateAsync(InspectActualProductionReqDto request)
        {

            var getActualproduction = await _dbContext.InspectActualProductions.FirstOrDefaultAsync(a => a.Id == request.Id);
            var actualproductionUpdated = _mapper.Map(request, getActualproduction);

            await _dbContext.SaveChangesAsync();


            return new BaseResponse<InspectActualProductionResultDto>
            {
                Data = _mapper.Map<InspectActualProductionResultDto>(actualproductionUpdated)
            };
        }
    }
}
