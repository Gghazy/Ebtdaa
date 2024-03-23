using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Interfaces
{
    public interface IInspectBasicFactInfoService
    {
        Task<BaseResponse<InspectBasicFactInfoResultDto>> AddAsync(InspectBasicFactInfoRequestDto request);
        Task<BaseResponse<InspectBasicFactInfoResultDto>> UpdateAsync(InspectBasicFactInfoRequestDto request);
        Task<BaseResponse<InspectBasicFactInfoResultDto>> GetOne(int FactoryId , int PeriodId , string OwnerIdentity);
    }
}
