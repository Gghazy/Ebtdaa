using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionActualProduction.Interfaces
{
    public interface IInspectActualProductionService
    {
        Task<BaseResponse<InspectActualProductionResultDto>> AddAsync(InspectActualProductionReqDto result);
        Task<BaseResponse<InspectActualProductionResultDto>> UpdateAsync(InspectActualProductionReqDto result);
        Task<BaseResponse<InspectActualProductionResultDto>> GetOne(int factoryId , int periodId , string ownerIdentity);
    }
}
